using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class PostTagsController : Controller
    {
        PostTagsRepository db = new PostTagsRepository();
        PostRepository postrep = new PostRepository();
        TagsRepository tagrep = new TagsRepository();

        private void GetPostList()
        {
            List<SelectListItem> postname = (from i in postrep.GetAll()
                                             select new SelectListItem
                                             {
                                                    Text = i.title,
                                                    Value = i.id.ToString()
                                             }).ToList();

            ViewBag.post = postname;
        }
        private void GetTagNameList()
        {
            List<SelectListItem> tagname = (from i in tagrep.GetAll()
                                            select new SelectListItem
                                             {
                                                 Text = i.name,
                                                 Value = i.Id.ToString()
                                             }).ToList();

            ViewBag.tag = tagname;
        }


        [HttpGet]
        public ActionResult Index()
        {
            GetPostList();
            GetTagNameList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(post_tags post)
        {
            db.Add(new post_tags
            {
                postId = post.postId,
                tagsId = post.tagsId
            });
            return View();
        }
        public PartialViewResult PartialPostTags()
        {
            var values = db.GetView();
            return PartialView("_PartialPostTags", values);
        }
        public ActionResult Delete(int id)
        {
            db.Remove(new post_tags { Id = id });
            return RedirectToAction("Index", "PostTags");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            GetPostList();
            GetTagNameList();

            return View(db.getById(id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Update(post_tags post)
        {
            db.Update(new post_tags
            {
                Id = post.Id,
                postId = post.postId,
                tagsId = post.tagsId
            });
            return RedirectToAction("Index", "PostTags");
        }

    }
}