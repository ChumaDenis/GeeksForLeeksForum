using GeeksForLessForum.Context;
using GeeksForLessForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace GeeksForLessForum.Controllers
{
    
    public class TopicController : Controller
    {
        private readonly TopicDbContext _topic;
        private readonly PostDbContext _post;

        public TopicController(TopicDbContext topic, PostDbContext post)
        {
            _topic = topic;
            _post = post;
        }
        
        public IActionResult Index(int id)
        {
            ViewBag.Posts = _post.PostsInfo.ToList().Where(x => x.IdOfTopic == id).ToList();
            return View(_topic.topics.ToList().Find(x => x.Id == id));
        } 
        [Authorize]
        public IActionResult CreateTopic()
        {

            return View();
        }
        [Authorize]
        public IActionResult Add(Topic topic)
        {
            if (topic == null)
            {
                return RedirectToAction("Error", "Home");
            }
            topic.UserName = this.User.Identity.Name;
            topic.CreatedDate = DateTime.Now;
            _topic.topics.Add(topic);
            _topic.SaveChanges();
            return RedirectToAction("Index", "Home", _topic.topics.ToList());
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var topic = _topic.topics.ToList().Find(x => x.Id == id);
            if(topic !=null)
            {
                _topic.topics.Remove(topic);
                _topic.SaveChanges();
            }

            return RedirectToAction("Index", "Home", _topic.topics.ToList());
        }


        public IActionResult AddPost(int id, Post post)
        {
            if (post == null)
            {
                return RedirectToAction("Error", "Home");
            }
            post.IdOfTopic = id;
            post.CreatedDate = DateTime.Now;
            post.UserName = "denis";
            post.UserName = this.User.Identity.Name;
            _post.PostsInfo.Add(post);
            _post.SaveChanges();
            ViewBag.Posts = _post.PostsInfo.ToList().Where(x => x.IdOfTopic == id).ToList();
            return RedirectToAction("Index", "Topic", _topic.topics.ToList().Find(x => x.Id == id));
        }

    }
}
