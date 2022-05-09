using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Loja.API.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(typeof(ExceptionHandlerExtensions));
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                       
                            logger.LogError($"Something went wrong: {contextFeature.Error}\n - Request: {FormatRequest(context.Request)}");
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new
                            {
                                Code = string.Empty,
                                Message = contextFeature.Error.Message
                            }));
                        }
                });
            });
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            MemoryStream contentStream = new MemoryStream();

            await request.Body.CopyToAsync(contentStream);
            contentStream.Position = 0;
            var bodyAsText = Encoding.UTF8.GetString(contentStream.ToArray());
            request.Body = contentStream;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";


        }
    }

}
