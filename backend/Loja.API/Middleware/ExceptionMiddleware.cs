//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Loja.API.Middleware
//{
//    public class ExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;
        
//        private readonly ILogger _logger;

//        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
//        {
//            _next = next;
//            _logger = loggerFactory
//                       .CreateLogger<ExceptionMiddleware>();
//        }

//        public async Task InvokeAsync(HttpContext httpContext)
//        {
//            try
//            {
//                await _next(httpContext);
//            }
//            catch (Exception ex)
//            {
//                await WriteLog(httpContext, ex);
//                await HandleGlobalExceptionAsync(httpContext, ex);
//            }
//        }

//        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//            return context.Response.WriteAsync(new
//            {
//                StatusCode = context.Response.StatusCode,
//                Message = "Something went wrong !Internal Server Error"
//            }.ToString());
//        }

//        public async Task WriteLog(HttpContext context, Exception ex)
//        {
//            string messageReq = await FormatRequest(context.Request);
//            _logger.LogError(ex, messageReq);
//        }

//        private async Task<string> FormatRequest(HttpRequest request)
//        {
//            MemoryStream contentStream = new MemoryStream();

//            await request.Body.CopyToAsync(contentStream);
//            contentStream.Position = 0;
//            var bodyAsText = Encoding.UTF8.GetString(contentStream.ToArray());
//            request.Body = contentStream;

//            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";


//        }

//        private async Task<string> FormatResponse(HttpResponse response)
//        {
//            response.Body.Seek(0, SeekOrigin.Begin);
//            var text = await new StreamReader(response.Body).ReadToEndAsync();
//            response.Body.Seek(0, SeekOrigin.Begin);

//            return $"Response {text}";
//        }
//    }
//}
