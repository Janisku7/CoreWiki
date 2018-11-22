using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public class I18nService : II18nService
	{
		private readonly IHttpApiClientRequestBuilderFactory httpApiClientRequestBuilderFactory;
		private Lazy<Task<Dictionary<string, string>>> translations;

		public I18nService(IHttpApiClientRequestBuilderFactory httpApiClientRequestBuilderFactory)
		{
			this.httpApiClientRequestBuilderFactory = httpApiClientRequestBuilderFactory;
			translations = new Lazy<Task<Dictionary<string, string>>>(() => FetchTranslations(null));
		}

		private async Task<Dictionary<string,string>> FetchTranslations(string lg)
		{
			var client = httpApiClientRequestBuilderFactory.Create("/api/articleslug");
			if (lg != null)
				client.SetHeader("accept-language", lg);
			Dictionary<string, string> res = null;
			await client.OnOK<Dictionary<string, string>>(r => res = r).GetAsync();
			return res;
		}

		public async Task<string> Get(string key)
		{
			return !(await translations.Value).TryGetValue(key, out var value) ? key : value;
		}

		public void Init(string lg)
		{
			translations = new Lazy<Task<Dictionary<string, string>>> (() => FetchTranslations(lg));
		}
	}
}
