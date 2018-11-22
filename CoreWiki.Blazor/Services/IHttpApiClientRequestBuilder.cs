using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public interface IHttpApiClientRequestBuilder
	{
		Task GetAsync();
		HttpApiClientRequestBuilder OnOK<T>(Action<T> todo);
		void SetHeader(string v, string lg);
	}
}
