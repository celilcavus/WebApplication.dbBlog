using _01_WebApplication.dbBlog.Entity.Entity;
using _03_WebApplication.dbBlog.DataAcsessLayer.Repository;
using System.Web.Mvc;

namespace WebApplication.dbBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository rep = new ContactRepository();
      
        public ActionResult Index()
        {
            return View(rep.GetAll());
        }
        
    }
}