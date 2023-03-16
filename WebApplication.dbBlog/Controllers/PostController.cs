using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebApplication.dbBlog.Controllers
{
    public class PostController : Controller
    {
        PostRepository rep = new PostRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(posts posts)
        {
            rep.Add(new posts
            {
                title = posts.title,
                content = posts.content,
                imageUrl = posts.imageUrl,
                created_at = posts.created_at,
                authorId = posts.authorId,
                categoryId = posts.categoryId,
                status = posts.status,
            });
            return View();
        }
        public PartialViewResult GetPostList()
        {
            var value = rep.GetAll().Where(x => x.status == true.ToString()).ToList();
            return PartialView("_GetPostList", value);
        }

        public ActionResult Delete(int id)
        {
            rep.Remove(new posts { id = id });
            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = rep.getById(id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(posts posts)
        {
            rep.Update(new posts
            {
                id = posts.id,
                title = posts.title,
                content = posts.content,
                imageUrl = posts.imageUrl,
                updated_at = posts.updated_at,
                authorId = posts.authorId,
                categoryId = posts.categoryId,
                status = posts.status,
            });
            return RedirectToAction("Index", "Post");
        }

        public ActionResult Details(int id)
        {
            var value = rep.getById(id);
            return View(value);
        }

    }
}