﻿using System;
using System.Collections.Generic;
using NodaTime;

namespace CoreWiki.Shared.ViewModels
{
	public class ArticleDetails
	{
		public bool IsHomePage { get; set; }
		public int Id { get; set; }
		public Guid AuthorId { get; set; }
		public string Slug { get; set; }
		public string Topic { get; set; }
		public string Content { get; set; }
		public Instant Published { get; set; }
		public int ViewCount { get; set; }
		public int Version { get; set; }

		public IReadOnlyCollection<Comment> Comments { get; set; }

	}
}
