using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.Components.PassworHasher;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Users;
using HotelLinenManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotelLinenManagement.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHasher passwordHasher)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            if (!Request.Headers.ContainsKey("Role"))
            {
                return AuthenticateResult.Fail("Missing Authorization Role");
            }

            var role = (AppRole)Enum.Parse(typeof(AppRole),
                Request.Headers.Where(x => x.Key == "role").Select(x => x.Value).FirstOrDefault());

            if (role == AppRole.AdminHotel || role == AppRole.UserHotel || role == AppRole.UserLaundry)
            {
                return await UserAuthorization(role);
            }

            //else if (role == AppRole.UserHotel)
            //{
            //    return await UserHotelAuthorization(role);
            //}

            //else if (role == AppRole.UserLaundry)
            //{
            //    return await UserLuandryAuthorization(role);
            //}
            else
            {
                return AuthenticateResult.Fail("Missing Authorization");
            }
        }

        private async Task<AuthenticateResult> UserAuthorization(AppRole role)
        {
            User user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                //var password = credentials[1];
                var query = new GetUserQuery()
                {
                    Username = username

                };
                user = await this.queryExecutor.Execute(query);


                if (user == null)
                    return AuthenticateResult.Fail("Resource does not exist");

                var password = passwordHasher.HashToCheck(credentials[1], user.Salt);
                if (user.Password != password)
                {
                    return AuthenticateResult.Fail("Wrong password");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role.ToString()),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);

        }
    }
}