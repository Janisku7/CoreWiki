using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Models
{
	public class ArticleEdit
	{
		public int Id { get; set; }
		public string Topic { get; set; }
		public string Slug { get; set; }
		public string Content { get; set; }
	}
}
