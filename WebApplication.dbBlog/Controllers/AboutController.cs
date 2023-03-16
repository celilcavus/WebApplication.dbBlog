using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository rep = new AboutRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(about item)
        {
            rep.Add(new about
            {
                title = item.title,
                description = item.description,
                githup = item.githup,
                linkedin = item.linkedin,
                twitter = item.twitter,
                facebook = item.facebook,
                youtube = item.youtube,
                instagram = item.instagram
            });
            return View();
        }


        public ActionResult Delete(int id)
        {
            if(id != 0 || id <= 0)
            {
                int i = rep.Remove(new about { Id = id });
                if (i >= 1)
                {
                    return RedirectToAction("Index", "About");
                }
            }
            return Redirect("_PartialPage404");
        }
        public PartialViewResult PartialGetAboutList()
        {
            var returnvalue = rep.GetAll();
            return PartialView("_PartialGetAboutList", returnvalue);
        }
    }
}