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
        
        public IActionResult Index(int id, string Response="none")
        {
            ViewBag.Posts = _post.PostsInfo.ToList().Where(x => x.IdOfTopic == id).ToList();
            
            ViewBag.Response = Response;
            return View(_topic.TopicInfo.ToList().Find(x => x.Id == id));
        } 
        [Authorize]
        public IActionResult CreateTopic()
        {

            return View(_topic.TopicInfo.ToList());
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
            _topic.TopicInfo.Add(topic);
            _topic.SaveChanges();
            return RedirectToAction("Index", "Home", _topic.TopicInfo.ToList());
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var topic = _topic.TopicInfo.ToList().Find(x => x.Id == id);
            if(topic !=null)
            {
                _topic.TopicInfo.Remove(topic);
                _topic.SaveChanges();
            }
            return RedirectToAction("Index", "Home", _topic.TopicInfo.ToList());
        }

        public IActionResult AddPost(int id, Post post)
        {
            if (post == null)
            {
                return RedirectToAction("Error", "Home");
            }

            if (_post.PostsInfo.ToList().Find(x => x.UserName == post.Response) == null)
            {
                post.Response = "";
            }
            post.IdOfTopic = id;
            post.CreatedDate = DateTime.Now;
            post.UserName = "denis";
            post.UserName = this.User.Identity.Name;
            if(post.UserName!="")
            {
                post.UserName = "guest";
            }
            _post.PostsInfo.Add(post);
            _post.SaveChanges();
            ViewBag.Posts = _post.PostsInfo.ToList().Where(x => x.IdOfTopic == id).ToList();
            
            return RedirectToAction("Index", "Topic", _topic.TopicInfo.ToList().Find(x => x.Id == id));
        }



    }
}
