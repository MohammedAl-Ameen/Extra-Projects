using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class moviesController : Controller
    {
        // GET: movies
        public ActionResult Random()
        {
            var movie = new movie() { name = "Shrek!" };
            
            return View(movie);
/*          return Content("hello world");
            return HttpNotFound();
            return new EmptyResult();
            return redirectoaction("Index" , "Home" , new{page = 1, sortBy="name"});
 */
        }

        public ActionResult edit(int id)
        {
            return Content("id=" + id);
        }


        public ActionResult index(int? pageindex , string sortby)
        {
            if (!pageindex.HasValue)
            {
                pageindex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortby))
            {
                sortby = "name";
            }


            return Content(string.Format("pageIndex={0}&sortby={1}", pageindex , sortby));
        }
    }
}