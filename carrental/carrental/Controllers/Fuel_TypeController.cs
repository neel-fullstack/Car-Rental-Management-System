using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class Fuel_TypeController : Controller
    {
        carrentalEntities dc = new carrentalEntities();
        // GET: Fuel_Type
        public ActionResult Index()
        {
            List<Fuel_Type> lst = dc.Fuel_Type.ToList();

            return View(lst);

        }

        // GET: Fuel_Type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fuel_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuel_Type/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Fuel_Type f)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Fuel_Type.Add(f);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fuel_Type/Edit/5
        public ActionResult Edit(int id)
        {
            Fuel_Type f = dc.Fuel_Type.Find(id);
            return View(f);
        }

        // POST: Fuel_Type/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, Fuel_Type f)
        {
            try
            {
                // TODO: Add update logic here
                dc.Entry(f).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fuel_Type/Delete/5
        public ActionResult Delete(int id)
        {
            Fuel_Type f = dc.Fuel_Type.Find(id);
            dc.Fuel_Type.Remove(f);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Fuel_Type/Delete/5
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
