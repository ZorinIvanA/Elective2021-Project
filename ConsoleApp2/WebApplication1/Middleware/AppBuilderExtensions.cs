using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Middleware
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder app,
            ILogger logger)
        {
            return app.Use((req, next) =>
            {
                logger.LogInformation($"Request {req.Request.Path} started");
                return next.Invoke();
            });
        }
    }
}
