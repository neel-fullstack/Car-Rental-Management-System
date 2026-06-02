using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        carrentalEntities dc = new carrentalEntities();
        public ActionResult Index()
        {
            List<City> lst = dc.Cities.ToList();

            return View(lst);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, City c)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Cities.Add(c);
                dc.SaveChanges();
                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            City c = dc.Cities.Find(id);
            return View(c);
            
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, City c)
        {
            try
            {
                // TODO: Add update logic here

                dc.Entry(c).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            City c = dc.Cities.Find(id);
            dc.Cities.Remove(c);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: City/Delete/5
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
