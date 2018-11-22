using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public class HttpApiClientRequestBuilderFactory : IHttpApiClientRequestBuilderFactory
	{
		private readonly HttpClient _httpClient;
		private readonly IBrowserCookieService browserCookieService;
		public HttpApiClientRequestBuilderFactory(HttpClient httpClient, IBrowserCookieService browserCookieService)
		{
			_httpClient = httpClient;
			this.browserCookieService = browserCookieService;
		}
		public IHttpApiClientRequestBuilder Create(string url)
		{
			return new HttpApiClientRequestBuilder(_httpClient, url, browserCookieService);
		}
	}
}
