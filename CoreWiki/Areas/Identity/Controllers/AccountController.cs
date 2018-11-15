using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWiki.Data.EntityFramework.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWiki.Areas.Identity.Controllers
{
	/// <summary>
	/// Handling registration to coreWiki from Connected Clients
	/// Perhaps able to handle GDPR this way too.
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
		private readonly UserManager<CoreWikiUser> _userManager;

		public AccountController(UserManager<CoreWikiUser> userManager)
		{
			_userManager = userManager;
		}
    }
}
