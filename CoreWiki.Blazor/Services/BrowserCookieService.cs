using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public class BrowserCookieService : IBrowserCookieService
	{
		public async Task<string> Get(Func<string, bool> filterCookie)
		{
			return (await JsInterop
				.GetCookie())
				.Split(';')
				.Select(v => v.TrimStart().Split('='))
				.Where(s => filterCookie(s[0]))
				.Select(s => s[1])
				.FirstOrDefault();
		}
	}
}
