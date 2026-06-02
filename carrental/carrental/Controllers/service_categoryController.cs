using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class service_categoryController : Controller
    {
        // GET: service_category
        carrentalEntities dc = new carrentalEntities();
        public ActionResult Index()
        {
            List<service_category> lst = dc.service_category.ToList();

            return View(lst);
        }

        // GET: service_category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: service_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: service_category/Create
        [HttpPost]
        public ActionResult Create(service_category sc)
        {
            try
            {
                // TODO: Add insert logic here
                dc.service_category.Add(sc);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: service_category/Edit/5
        public ActionResult Edit(int id)
        {
            service_category sc = dc.service_category.Find(id);
            return View(sc);
        }

        // POST: service_category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, service_category sc)
        {
            try
            {
                // TODO: Add update logic here
                dc.Entry(sc).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: service_category/Delete/5
        public ActionResult Delete(int id)
        {
            service_category sc = dc.service_category.Find(id);
            dc.service_category.Remove(sc);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: service_category/Delete/5
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
