using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Services
{
	public interface II18nService
	{
		Task<string> Get(string name);
		void Init(string lg);
	}
}
