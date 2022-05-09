﻿//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;

//namespace Loja.API.Middleware
//{
//    public class RequestResponseLoggingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger _logger;

//        public RequestResponseLoggingMiddleware(RequestDelegate next,
//                                                ILoggerFactory loggerFactory)
//        {
//            _next = next;
//            _logger = loggerFactory
//                      .CreateLogger<RequestResponseLoggingMiddleware>();
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            _logger.LogInformation(await FormatRequest(context.Request));

//            var originalBodyStream = context.Response.Body;

//            using (var responseBody = new MemoryStream())
//            {
//                context.Response.Body = responseBody;

//                await _next(context);

//                _logger.LogInformation(await FormatResponse(context.Response));
//                await responseBody.CopyToAsync(originalBodyStream);
//            }
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
