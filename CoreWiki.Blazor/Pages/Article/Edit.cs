using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Blazor.Components;
using static CoreWiki.Blazor.Pages.__Edit;
using Microsoft.AspNetCore.Authorization;

namespace CoreWiki.Blazor.Pages.Article
{
	//[Authorize(Policy= PolicyConstants.CanEditArticles)]
	public class EditComponent : BlazorComponent
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly ILogger _logger;
		public EditComponent (IMediator mediator, IMapper mapper, ILoggerFactory loggerFactory)
		{
			_mediator = mediator;
			_mapper = mapper;
			_logger = loggerFactory.CreateLogger("EditPage");
		}

		
		public ArticleEdit Article { get; set; }
		//public async Task<object> OnGetAsync(string slug)
		//{
		//	if (slug == null)
		//	{
		//		return NotFound();
		//	}
		//	var article = await _mediator.Send(new GetArticleQuery(slug));
		//	Article = _mapper.Map<ArticleEdit>(article);
		//	return Page();
		//}

	}
}
