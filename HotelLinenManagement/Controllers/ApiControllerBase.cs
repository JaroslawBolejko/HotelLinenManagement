using HotelLinenManagement.ApplicationServices.API.Domain;
using HotelLinenManagement.ApplicationServices.API.Domain.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelLinenManagement.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                         this.ModelState
                         .Where(x => x.Value.Errors.Any())
                         //tu wyciągamy te wartości naszych błędów do potestowania!
                         .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }
            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResopnse(response.Error);
            }

            return this.Ok(response);
        }

        private IActionResult ErrorResopnse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                //case ErrorType.ValidationError:
                //    return HttpStatusCode.Validation;
                //case ErrorType.NotAuthenticated:
                //    return HttpStatusCode.NotAuthenticated;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.TooManyRequests:
                    return HttpStatusCode.TooManyRequests;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
