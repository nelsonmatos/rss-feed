using Microsoft.AspNetCore.Mvc;
using RSSFeed.Common.Utilities.Collections.LinkedList;

namespace RSSFeed.Modules.News.Controllers
{
    [Route("api/v1/linked-list")]
    public class LinkedListController : Controller
    {
        [HttpGet]
        public dynamic Get()
        {
            LinkedList list = new();

            list.Push("First element");
            list.Push("Second element");
            list.Push("Unshift new first element");

            return list.Count();
        }
    }
}
