using Microsoft.AspNetCore.Http;
using Serilog;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.API.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log de la solicitud (request)
            context.Request.EnableBuffering();
            var requestBody = await ReadRequestBodyAsync(context.Request);
            Log.Information("HTTP Request: {Method} {Path} {Body}", context.Request.Method, context.Request.Path, requestBody);

            // Interceptar la respuesta (response)
            var originalResponseBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            // Log de la respuesta (response)
            var responseBodyText = await ReadResponseBodyAsync(responseBody);
            Log.Information("HTTP Response: {StatusCode} {Body}", context.Response.StatusCode, responseBodyText);

            await responseBody.CopyToAsync(originalResponseBodyStream);
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }

        private async Task<string> ReadResponseBodyAsync(Stream responseBody)
        {
            responseBody.Position = 0;
            using var reader = new StreamReader(responseBody, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            responseBody.Position = 0;
            return body;
        }
    }
}
