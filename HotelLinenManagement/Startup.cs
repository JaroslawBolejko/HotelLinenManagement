using FluentValidation.AspNetCore;
using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Mappings;
using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.CQRS;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HotelLinenManagement.ApplicationServices.API.Validators;
using Microsoft.AspNetCore.Mvc;
using HotelLinenManagement.ApplicationServices.Components.GetGusDataAPIByTaxNumber;
using Microsoft.AspNetCore.Authentication;
using HotelLinenManagement.Authentication;
using HotelLinenManagement.ApplicationServices.Components.PassworHasher;

namespace HotelLinenManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddStoreroomRequestValidator>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddTransient<IGUSDataConnector, GUSDataConnector>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
                        services.AddTransient<IQueryExecutor, QueryExecutor>();

            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddAutoMapper(typeof(HotelLinensProfile).Assembly);

            services.AddMediatR(typeof(ResponseBase<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<HotelLinenWarehouseContext>(
                opt =>
                opt.UseSqlServer(this.Configuration.GetConnectionString("HotelLinenWarhauseConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelLinenManagement", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelLinenManagement v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
