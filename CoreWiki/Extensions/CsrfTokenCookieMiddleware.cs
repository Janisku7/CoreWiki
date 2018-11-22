using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Extensions
{
	public class CsrfTokenCookieMiddleware
	{
		private readonly IAntiforgery _antiForgery;
		private readonly RequestDelegate _next;

		public CsrfTokenCookieMiddleware(IAntiforgery antiforgery, RequestDelegate next)
		{
			_antiForgery = antiforgery;
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			if (context.Request.Cookies["CSRF-TOKEN"]==null)
			{
				var token = _antiForgery.GetAndStoreTokens(context);
				context.Response.Cookies.Append("CSRF-TOKEN", token.RequestToken, new CookieOptions { HttpOnly = false });
			}
			await _next(context);
		}
	}
}
