using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public class HttpApiClientRequestBuilder : IHttpApiClientRequestBuilder
	{
		private readonly string _uri;
		private HttpClient _httpClient;
		private Func<HttpResponseMessage, Task> _onOK;
		private IBrowserCookieService browserCookieService;

		public HttpApiClientRequestBuilder(HttpClient httpClient, string uri, IBrowserCookieService browserCookieService)
		{
			_uri = uri;
			_httpClient = httpClient;
			this.browserCookieService = browserCookieService;
		}
		public async Task GetAsync()
		{
			await ExecuteHttpQueryAsync(async () => await _httpClient.SendAsync(await PrepareMessageAsync(new HttpRequestMessage(HttpMethod.Get, _uri))));
		}

		public HttpApiClientRequestBuilder OnOK<T>(Action<T> todo)
		{
			_onOK = async (HttpResponseMessage r) =>
			{
				var response = Json.Deserialize<T>(await r.Content.ReadAsStringAsync());
				todo(response);
			};
			return this;
		}
		public void SetHeader(string key, string value)
		{
			_httpClient.DefaultRequestHeaders.Add(key, value);
		}
		private async Task HandleHttpResponseAsync(HttpResponseMessage response)
		{
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					if (_onOK != null)
						await _onOK(response);
					break;
				case HttpStatusCode.BadRequest:
					break;
				case HttpStatusCode.InternalServerError:
					break;
			}
		}
		private async Task<HttpRequestMessage> PrepareMessageAsync(HttpRequestMessage httpRequestMessage)
		{
			var csrfCookieValue = await browserCookieService.Get(c => c.Equals("CSRF-TOKEN"));
			if (csrfCookieValue != null)
				httpRequestMessage.Headers.Add("X-CSRF-TOKEN", csrfCookieValue);
			return httpRequestMessage;
		}
		private async Task ExecuteHttpQueryAsync(Func<Task<HttpResponseMessage>> httpCall)
		{
			try
			{
				var response = await httpCall();
				await HandleHttpResponseAsync(response);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{

			}
		}
	}
}
