using CoreWiki.Configuration.Settings;
using CoreWiki.Configuration.Startup;
using CoreWiki.Data.EntityFramework.Security;
using CoreWiki.FirstStart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.ResponseCompression;
using System.Linq;
using System.Net.Mime;

namespace CoreWiki
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			
			services.ConfigureAutomapper();
			services.AddResponseCompression(options =>
			options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
			{
				MediaTypeNames.Application.Octet,
				WasmMediaTypeNames.Application.Wasm,
			}));
			services.ConfigureRSSFeed();
			services.Configure<AppSettings>(Configuration);
			services.ConfigureSecurityAndAuthentication();
			services.ConfigureDatabase(Configuration);
			services.ConfigureScopedServices(Configuration);
			services.ConfigureHttpClients();
			services.ConfigureRouting();
			services.ConfigureLocalisation();
			services.ConfigureApplicationServices();
			services.AddMediator();
			services.AddServerSideBlazor<Blazor.Startup>();
			
			
			services.AddFirstStartConfiguration(Configuration);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings, UserManager<CoreWikiUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			app.UseResponseCompression();
			app.ConfigureTelemetry();
			app.ConfigureExceptions(env);
			app.ConfigureSecurityHeaders(env);
			app.ConfigureRouting();
			app.InitializeData(Configuration);

			app.UseFirstStartConfiguration(env, Configuration, () => Program.Restart());

			var theTask = app.ConfigureAuthentication(userManager, roleManager);
			theTask.GetAwaiter().GetResult();
			app.ConfigureRSSFeed(settings);
			app.ConfigureLocalisation();

			app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");

			app.UseMvc();
			
			app.UseServerSideBlazor<Blazor.Startup>();
			
		}
	}
}
