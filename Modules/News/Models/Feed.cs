using System.Collections.Generic;

namespace RSSFeed.Modules.News.Models
{
    public class Entry
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public List<string> Authors { get; set; }
    }

    public class Image
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class Feed
    {
        public string Title { get; set; }
        public int AuthorsToday { get; set; } = 0;
        public string Desc { get; set; }
        public Image Img { get; set; }
        public List<Entry> Entries { get; set; }
    }
}