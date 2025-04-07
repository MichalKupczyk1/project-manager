using Microsoft.AspNetCore.Diagnostics;
using ProjectManager.Domain.Exceptions;
using System.Net;

namespace ProjectManager.Middleware.Exception
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var message = string.Empty;
                        var errors = new List<string>();
                        switch (contextFeature.Error)
                        {
                            case BadRequestException ex:
                                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                                message = ex.Message;
                                break;
                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                message = "Internal server error";
                                break;
                        }
                        await context.Response.WriteAsync(new ErrorDetails() { Message = message }.ToString());
                    }
                });
            });
        }
    }
}
