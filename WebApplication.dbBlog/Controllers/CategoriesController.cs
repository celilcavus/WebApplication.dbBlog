using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesRepository rep = new CategoriesRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(categories item)
        {
            int i = rep.Add(new categories
            {
                name = item.name,
                description = item.description
            });

            if (i>=1)
            {
              return RedirectToAction("Index", "Categories");
            }
            else
            return HttpNotFound();
        }
    
        public PartialViewResult GetViewResult()
        {
            var returnList = rep.GetAll();
            return PartialView("_PartialCategoryList",returnList);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var getList = rep.getById(id).FirstOrDefault();
            return View(getList);
        }
      
        [HttpPost]
        public ActionResult Update(categories item)
        {
            int i = rep.Update(new categories
            {
                Id = item.Id,
                name = item.name,
                description = item.description
            });

            if (i >= 1)
            {
                return RedirectToAction("Index", "Categories");
            }
            else
                return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            int i = rep.Remove(new categories
            {
                Id = id
            });
            if (i >= 1)
            {
                return RedirectToAction("Index", "Categories");
            }
            else
                return HttpNotFound();

        }

    }
}