using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace KJK.Server.Middlewares
{
	public class LoggerMiddleware
	{
		private RequestDelegate Next{ get; set; }
		private ILogger<LoggerMiddleware> Logger { get; set; }

		public LoggerMiddleware(ILogger<LoggerMiddleware> logger,RequestDelegate next)
		{
			Logger = logger;
			Next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			using (var scope = Logger.BeginScope(Guid.NewGuid().ToString().Substring(0, 6)))
			{
				await Next(httpContext);
			}
		}
	}
}
