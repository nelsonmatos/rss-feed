using Microsoft.AspNetCore.Mvc;
using RSSFeed.Modules.News.Controllers;
using RSSFeed.Modules.News.Services;

namespace RSSFeed.Modules.News.Controllers
{
    [Route("api/v1/news")]
    public class NewsController : Controller
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public dynamic Get([FromQuery] string feed)
        {
            return Json(_newsService.Get(feed));
        }
    }
}
