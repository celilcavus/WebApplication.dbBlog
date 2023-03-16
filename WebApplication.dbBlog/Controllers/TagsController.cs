using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class TagsController : Controller
    {
        TagsRepository rep = new TagsRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tags item)
        {
            int i = rep.Add(new tags
            {
                name = item.name,
                description = item.description
            });

            if (i >= 1)
            {
                return RedirectToAction("Index", "Tags");
            }
            else
                return HttpNotFound();
        }
    
        public PartialViewResult PartialGetTagsList()
        {
            var returnvalue = rep.GetAll();
            return PartialView("_PartialGetTagsList", returnvalue);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var returnVal = rep.getById(id).FirstOrDefault();
            return View(returnVal);
        }

        [HttpPost]
        public ActionResult Update(tags item)
        {
            int i = rep.Update(new tags
            {
                Id = item.Id,
                name = item.name,
                description = item.description
            });

            if (i >= 1)
            {
                return RedirectToAction("Index", "Tags");
            }
            else
                return HttpNotFound();
        }

      
        public ActionResult Delete(int id)
        {
            int i = rep.Remove(new tags{Id = id});

            if (i >= 1)
            {
                return RedirectToAction("Index", "Tags");
            }
            else
                return HttpNotFound();
        }
    }
}