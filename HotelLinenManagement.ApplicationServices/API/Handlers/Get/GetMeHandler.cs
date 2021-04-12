using AutoMapper;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using HotelLinenManagement.ApplicationServices.API.Domain.Requests.Users;
using HotelLinenManagement.ApplicationServices.API.Domain.Responses.Users;
using HotelLinenManagement.DataAccess.CQRS;
using HotelLinenManagement.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace HotelLinenManagement.ApplicationServices.API.Handlers
{
    public class GetMeHandler : IRequestHandler<GetMeRequest, GetMeResponse>
    {

        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMeHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {

            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetMeResponse> Handle(GetMeRequest request, CancellationToken cancellationToken)
        {

            if (request.Me == "Me" || request.Me == "me")
            {

                var query = new GetUserQuery()
                {
                    Username = request.AuthenticationName
                };

                var user = await this.queryExecutor.Execute(query);

                if (user == null)
                {
                    return new GetMeResponse()
                    {
                        Error = new ErrorModel(ErrorType.NotFound)
                    };
                }
                var mappedUser = this.mapper.Map<Domain.Models.User>(user);

                var response = new GetMeResponse()
                {
                    Data = mappedUser
                };
                return response;
            }
            else
            {
                return new GetMeResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

        }
    }
}


