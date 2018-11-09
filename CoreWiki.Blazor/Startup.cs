
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWiki.Blazor
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			
			services.AddScoped<AppState>();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
			
		}
	}
}
