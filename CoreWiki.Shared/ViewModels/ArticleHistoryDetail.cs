using NodaTime;

namespace CoreWiki.Shared.ViewModels
{
	public class ArticleHistoryDetail
	{
		public int Version { get; set; }
		public string AuthorName { get; set; }
		public Instant Published { get; set; }
	}
}
