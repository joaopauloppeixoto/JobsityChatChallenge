using JobsityApi.Utils.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace JobsityApi.Utils;


public class GlobalExceptionMiddleware : IMiddleware
{
    public GlobalExceptionMiddleware()
    {

    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomException customException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();

            var problemDetails = new ValidationProblemDetails
            {
                Type =
                    $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{HttpStatusCode.Forbidden.GetHashCode()}",
                Title = customException.Message,
                Status = HttpStatusCode.Forbidden.GetHashCode(),
                Detail = customException.InnerException?.Message,
                Instance = customException.Source
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
        catch (Exception argumentException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();

            var problemDetails = new ValidationProblemDetails
            {
                Type =
                    $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{HttpStatusCode.InternalServerError.GetHashCode()}",
                Title = argumentException.Message,
                Status = HttpStatusCode.InternalServerError.GetHashCode(),
                Detail = argumentException.InnerException?.Message,
                Instance = argumentException.Source
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
