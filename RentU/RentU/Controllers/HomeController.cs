using Microsoft.AspNet.Identity;
using RentU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }

        public ActionResult Details(int ItemId)
        {
            var item = db.Items.Find(ItemId);

            if(item == null)
            {
                return HttpNotFound();
            }

            Session["ItemId"] = ItemId;

            return View(item);
        }

        public ActionResult getitem()
        {
            var userId = User.Identity.GetUserId();
            var item = db.AddItems.Where(a => a.Userid == userId);
            return View(item.ToList());
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult ADD()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ADD(string Message)
        {
            var Userid = User.Identity.GetUserId();
            var itemid = (int)Session["ItemId"];
            var check = db.AddItems.Where(a => a.Itemid == itemid && a.Userid == Userid).ToList();
            var item = new Additems();

            item.Userid = Userid;
            item.Itemid = itemid;
            item.Message = Message;
            item.Buydate = DateTime.Now;
            db.AddItems.Add(item);
            db.SaveChanges();
            ViewBag.Result = "The message was sent";
            return View();
        }
    }
}