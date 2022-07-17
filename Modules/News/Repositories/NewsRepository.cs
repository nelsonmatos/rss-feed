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
                throw new Exception("Empty rss feed");
            }

            Feed feed = new()
            {
                Title = rssFeedResponse.Title?.Text,
                Desc = rssFeedResponse.Description?.Text
            };

            if (rssFeedResponse.ImageUrl != null)
            {
                feed.Img = new Image()
                {
                    Title = rssFeedResponse.Title?.Text,
                    Url = rssFeedResponse.ImageUrl?.ToString()
                };
            }

            if (rssFeedResponse.Items != null && rssFeedResponse.Items.Any())
            {
                feed.Entries = new List<Entry>();

                foreach (SyndicationItem item in rssFeedResponse.Items)
                {
                    Entry entry = new()
                    {
                        Title = item.Title?.Text,
                        Link = item.Links?.Select(l => l.Uri.AbsoluteUri).First(),
                        PubDate = item.PublishDate.AddHours(2).ToString("dd-MM-yyyy HH:mm:ss"),
                        Authors = item.Authors.Where(a => a.Name != null).Select(a => a.Name).ToList()
                    };

                    if (item.PublishDate.AddHours(2) >= DateTime.Now.AddDays(-1))
                    {
                        feed.AuthorsToday += item.Authors.Where(a => a.Name != null).ToList().Count();
                    }

                    feed.Entries.Add(entry);
                }
            }


            return feed;
        }
    }
}