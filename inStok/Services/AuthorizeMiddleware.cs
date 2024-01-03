using System;
using System.Net;
using System.Text.Json;

namespace inStok.Services
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.ContentType = "application/json";
                var response = new { Message = "Usuário não autenticado" };
                var responseJson = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}

