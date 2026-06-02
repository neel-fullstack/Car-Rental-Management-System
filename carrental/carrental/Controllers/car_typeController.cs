using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class car_typeController : Controller
    {
        carrentalEntities se = new carrentalEntities();
        // GET: car_type
        public ActionResult Index()
        {
            return View(se.car_type.ToList<car_type>());
        }

        // GET: car_type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: car_type/Create
        public ActionResult Create()
        {
            var data = new SelectList(se.Brands.ToList(), "Id", "brand_name");
            ViewData["car_type"] = data;
            var cardata = new SelectList(se.car_category.ToList(), "Category_Id", "Category_name");
            ViewData["category"] = cardata;
            var fdata = new SelectList(se.Fuel_Type.ToList(), "Fuel_ID", "Fuel_Type1");
            ViewData["fuel"] = fdata;
            var citydata = new SelectList(se.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            return View();
        }

        // POST: car_type/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase f1,car_type ct)
        {
            try
            {
                if (f1.ContentLength > 0)
                {
                    ct.images = f1.FileName;
                    string path = Server.MapPath("~/upload/") + f1.FileName;
                    f1.SaveAs(path);

                }
                // TODO: Add insert logic here
                se.car_type.Add(ct);
                se.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: car_type/Edit/5
        public ActionResult Edit(int id)
        {
            var data = new SelectList(se.Brands.ToList(), "Id", "brand_name");
            ViewData["car_type"] = data;
            var cardata = new SelectList(se.car_category.ToList(), "Category_Id", "Category_name");
            ViewData["category"] = cardata;
            var fueldata = new SelectList(se.Fuel_Type.ToList(), "Fuel_ID", "Fuel_Type1");
            ViewData["Fuel"] = fueldata;
            var citydata = new SelectList(se.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            car_type c = se.car_type.Find(id);
            car_category car = se.car_category.Find(id);
            Fuel_Type f = se.Fuel_Type.Find(id);
            City ci = se.Cities.Find(id);
            return View(c);
        }

        // POST: car_type/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase f1, car_type ct)
        {
            try
            {
                if (f1 != null)
                {
                    if (f1.ContentLength > 0)
                    {
                        ct.images = f1.FileName;
                        string path = Server.MapPath("~/upload/") + f1.FileName;
                        f1.SaveAs(path);

                    }
                }
                se.Entry(ct).State = System.Data.Entity.EntityState.Modified;
                se.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: car_type/Delete/5
        public ActionResult Delete(int id)
        {
            car_type ct = se.car_type.Find(id);
            se.car_type.Remove(ct);
            se.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: car_type/Delete/5
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
