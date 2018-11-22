using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public interface IHttpApiClientRequestBuilderFactory
	{
		IHttpApiClientRequestBuilder Create(string url);
	}
}
