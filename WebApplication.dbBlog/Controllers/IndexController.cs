using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class IndexController : Controller
    {
        ContactRepository rep = new ContactRepository();
        AboutRepository about = new AboutRepository();
        CategoriesRepository category = new CategoriesRepository();
        PostRepository post = new PostRepository();
        UsersRepository author = new UsersRepository();
        // GET: Index
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(string _title)
        {
            var values = post.GetAll().Where(x => x.title == _title).FirstOrDefault();
            return View(values);
        }
        public PartialViewResult PartialCategory()
        {
            var values = category.GetAll();
            return PartialView("_PartialCategory",values);
        }
        public PartialViewResult PartialSmallPost()
        {
            var values = post.GetAll();
            return PartialView("_PartialSmallPost", values);
        }
        public PartialViewResult PartialLastPost()
        {
            var values = post.GetAll().LastOrDefault();
            return PartialView("_PartialLastPost", values);
        }


        public ActionResult GetByIdCategory(int id)
        {
            var values = post.GetAll().Where(x => x.categoryId == id).ToList();
            return View(values);
        }

        public ActionResult ReadMore(int id)
        {
            var values = post.GetView().Where(x => x.id == id).FirstOrDefault();
            return View(values);
        }
        public ActionResult Author(int id)
        {
            var values = author.getById(id).FirstOrDefault();
            return View(values);
        }
      

        //Home sayfasından kullanıcı iletişime geçmesi için bu.
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(contact item)
        {
            int i = rep.Add(new contact
            {
                name = item.name,
                lastname = item.lastname,
                phoneNumber = item.phoneNumber,
                emailAdres = item.emailAdres,
                description = item.description
            });
            if (i >= 1)
            {
                
                return RedirectToAction("Contact", "Index");
            }
            
            return HttpNotFound();
        }


        [HttpGet]
        public ActionResult About()
        {
            var returnList = about.GetAll().LastOrDefault();
            return View(returnList);
        }
    }
}