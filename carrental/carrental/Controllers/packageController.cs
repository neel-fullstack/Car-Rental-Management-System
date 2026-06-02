using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class packageController : Controller
    {
        carrentalEntities se = new carrentalEntities();
        // GET: package
        public ActionResult Index()
        {
            return View(se.Packages.ToList<Package>());
        }

        // GET: package/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: package/Create
        public ActionResult Create()
        {
            var data = new SelectList(se.car_type.ToList(), "car_Id", "car_name");
            ViewData["car_type"] = data;
            return View();
        }

        // POST: package/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Package f)
        {
            try
            {
                // TODO: Add insert logic here
                se.Packages.Add(f);
                se.SaveChanges();
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }

        // GET: package/Edit/5
        public ActionResult Edit(int id)
        {
            var data = new SelectList(se.car_type.ToList(), "car_Id", "car_name");
            ViewData["car_type"] = data;
             car_type c = se.car_type.Find(id);
            return View();
        }

        // POST: package/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, Package f)
        {
            try
            {
                // TODO: Add update logic here
                se.Entry(f).State = System.Data.Entity.EntityState.Modified;
                se.SaveChanges();
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: package/Delete/5
        public ActionResult Delete(int id)
        {
            Package ct = se.Packages.Find(id);
            se.Packages.Remove(ct);
            se.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // POST: package/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
