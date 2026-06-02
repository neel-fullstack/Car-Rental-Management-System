using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class car_categoryController : Controller
    {
        carrentalEntities dc = new carrentalEntities();
        // GET: car_category
        public ActionResult Index()
        {
            List<car_category> lst = dc.car_category.ToList();

            return View(lst);

        }

        // GET: car_category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: car_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: car_category/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, car_category c)
        {
            try
            {
                dc.car_category.Add(c);
                dc.SaveChanges();
                return RedirectToAction("Index");
                // TODO: Add insert logic here

               
            }
            catch
            {
                return View();
            }
        }

        // GET: car_category/Edit/5
        public ActionResult Edit(int id)
        {
            car_category c = dc.car_category.Find(id);
            return View(c);
        }

        // POST: car_category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, car_category c)
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

        // GET: car_category/Delete/5
        public ActionResult Delete(int id)
        {
            car_category f = dc.car_category.Find(id);
            dc.car_category.Remove(f);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: car_category/Delete/5
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
