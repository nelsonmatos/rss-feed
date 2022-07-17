using System.Collections.Generic;

namespace RSSFeed.Modules.News.Models
{
    public class Entry
    {
        public string title { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public List<string> authors { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Feed
    {
        public string title { get; set; }
        public int authorsToday { get; set; } = 0;
        public string desc { get; set; }
        public Image img { get; set; }
        public List<Entry> entries { get; set; }
    }
}