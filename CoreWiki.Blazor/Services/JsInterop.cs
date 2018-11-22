using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public class JsInterop
	{
		public static async Task<string[]> Languages()
		{
			return await JSRuntime.Current.InvokeAsync<string[]>("navigatorLanguages");
		}
		public static async Task<string> GetCookie()
		{
			return await JSRuntime.Current.InvokeAsync<string>("getDocumentCookie");
		}
	}
}
