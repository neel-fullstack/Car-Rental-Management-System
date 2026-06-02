using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class FAQController : Controller
    {
        // GET: FAQ
        carrentalEntities dc = new carrentalEntities(); 
        public ActionResult Index()
        {
            List<FAQ> lst = dc.FAQs.ToList();

            return View(lst);

        }

        // GET: FAQ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, FAQ f)
        {
            try
            {
                // TODO: Add insert logic here
                dc.FAQs.Add(f);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FAQ/Edit/5
        public ActionResult Edit(int id)
        {
            FAQ f= dc.FAQs.Find(id);
            return View(f);
        }

        // POST: FAQ/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, FAQ f)
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

        // GET: FAQ/Delete/5
        public ActionResult Delete(int id)
        {
            FAQ f = dc.FAQs.Find(id);
            dc.FAQs.Remove(f);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: FAQ/Delete/5
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
