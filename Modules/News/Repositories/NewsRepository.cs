using RSSFeed.Modules.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSFeed.Modules.News.Repositories
{
    public interface INewsRepository
    {
        Feed Get(string endpoint);
    }

    public class NewsRepository : INewsRepository
    {
        public NewsRepository()
        {
        }

        public Feed Get(string endpoint)
        {
            XmlReader reader = XmlReader.Create(endpoint);
            SyndicationFeed rssFeedResponse = SyndicationFeed.Load(reader);
            reader.Close();

            if (rssFeedResponse == null)
            {
                throw new System.Exception("Empty rss feed");
            }

            Feed feed = new()
            {
                title = rssFeedResponse.Title?.Text,
                desc = rssFeedResponse.Description?.Text
            };

            if (rssFeedResponse.ImageUrl != null)
            {
                feed.img = new Image()
                {
                    title = rssFeedResponse.Title?.Text,
                    url = rssFeedResponse.ImageUrl?.ToString()
                };
            }

            if (rssFeedResponse.Items != null && rssFeedResponse.Items.Any())
            {
                feed.entries = new List<Entry>();

                foreach (SyndicationItem item in rssFeedResponse.Items)
                {
                    Entry entry = new()
                    {
                        title = item.Title?.Text,
                        link = item.Links?.Select(l => l.Uri.AbsoluteUri).First(),
                        pubDate = item.PublishDate.AddHours(2).ToString("dd-MM-yyyy HH:mm:ss"),
                        authors = item.Authors.Where(a => a.Name != null).Select(a => a.Name).ToList()
                    };

                    if (item.PublishDate.AddHours(2) >= DateTime.Now.AddDays(-1))
                    {
                        feed.authorsToday += item.Authors.Where(a => a.Name != null).ToList().Count();
                    }

                    feed.entries.Add(entry);
                }
            }


            return feed;
        }
    }
}