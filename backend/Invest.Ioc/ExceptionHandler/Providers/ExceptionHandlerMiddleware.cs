using Invest.Ioc.ExceptionHandler.Extensions;
using Invest.Ioc.ExceptionHandler.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Invest.Ioc.ExceptionHandler.Providers
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = async context =>
                {
                    var _exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (_exceptionHandler == null)
                        return;

                    var _statusCode = _exceptionHandler.Error is ApiException ? ((ApiException)_exceptionHandler.Error).StatusCode : HttpStatusCode.InternalServerError;

                    context.Response.StatusCode = (int)_statusCode;

                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(new ExceptionViewModel { Message = _exceptionHandler.Error.Message, StatusCode = _statusCode }.ToString());
                }
            });
        }
    }
}