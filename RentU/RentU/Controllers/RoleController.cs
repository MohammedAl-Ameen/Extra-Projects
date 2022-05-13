
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using RentU.Models;
using WebApplication1.Models;

namespace RentU.Controllers
{
    public class RoleController : Controller
    {
         ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
        public ActionResult Index()
        {

            return View(db.Roles.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
                
                return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {

                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                return View(role);
            
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null) {

                return HttpNotFound();
            }

            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")]IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {

                return HttpNotFound();
            }

            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            try {
                var myrole = db.Roles.Find(role.Id);
                db.Roles.Remove(myrole);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                return View(role);
            }
            }
    }
}
