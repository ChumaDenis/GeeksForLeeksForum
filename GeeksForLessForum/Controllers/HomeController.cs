using GeeksForLessForum.Context;
using GeeksForLessForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeeksForLessForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly TopicDbContext _topic;
        public HomeController(TopicDbContext topic)
        {
            _topic = topic;
        }

        public IActionResult Index()
        {
            return View(_topic.TopicInfo.ToList());
        }
        public IActionResult MyTopics()
        {
            return View("Index",_topic.TopicInfo.ToList().Where(x=>x.UserName==this.User.Identity.Name).ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}