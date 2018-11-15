using System.ComponentModel.DataAnnotations;

namespace CoreWiki.Shared.ViewModels
{
	public class ArticleCreate
	{

		[Required]
		public string Topic { get; set; }

		public string Content { get; set; }
	}
}

