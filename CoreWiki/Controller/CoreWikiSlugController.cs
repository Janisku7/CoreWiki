using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/// <summary>
/// Design to able to make calls from blazor and other future clients for Wiki
/// Can be Refactored in the future use as CoreWiki.API 
/// </summary>
namespace CoreWiki.Controller
{
	[Authorize]
	[Route("api/[controller]")]
	public class CoreWikiSlugController : ControllerBase
	{
		private IStringLocalizer<BlazorResource> StringLocalizer;
		public CoreWikiSlugController(IStringLocalizer<BlazorResource> stringLocalizer)
		{
			this.StringLocalizer = stringLocalizer;
		}
		[HttpGet]
		public ActionResult GetClientClientTransactions()
		{
			var res = new Dictionary<string, string>();
			return Ok(StringLocalizer.GetAllStrings().ToDictionary(s => s.Name, s=> s.Value));
		}

		// GET: api/<controller>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
