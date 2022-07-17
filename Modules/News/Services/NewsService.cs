using RSSFeed.Modules.News.Models;
using RSSFeed.Modules.News.Repositories;

namespace RSSFeed.Modules.News.Services
{
    public interface INewsService
    {
        Feed Get(string endpoint);
    }

    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public Feed Get(string endpoint)
        {
            return _newsRepository.Get(endpoint);
        }
    }
}
