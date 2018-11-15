using NodaTime;

namespace CoreWiki.Shared.ViewModels
{
	public class ArticleDelete
	{
		public string Topic { get; set; }
		public string Content { get; set; }
		public Instant Published { get; set; }
	}
}
