using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{

    public class driverController : Controller
    {
        carrentalEntities se = new carrentalEntities();

        // GET: driver
        public ActionResult Index()
        {
            List<Driver> lst = se.Drivers.ToList();
            return View(lst);
        }

        // GET: driver/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: driver/Create
        public ActionResult Create()
        {
            var citydata = new SelectList(se.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            return View();
        }

        // POST: driver/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, HttpPostedFileBase f1, Driver c)
        {
            try
            {
                // TODO: Add insert logic here
                if (file.ContentLength > 0)
                {
                    c.Driver_Image = file.FileName;
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    file.SaveAs(_path);
                 //    return RedirectToAction("Index");


                }

                if (f1.ContentLength > 0)
                {
                    c.Driver_Licence  = f1.FileName;
                    string _FileName = Path.GetFileName(f1.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    f1.SaveAs(_path);
                   
                }
                se.Drivers.Add(c);
                se.SaveChanges();
                return RedirectToAction("Index");


              //  ViewBag.Message = "File Uploaded Successfully!!";
                //return View();


            }
            catch
            {
                return View();
            }
        }

        // GET: driver/Edit/5
        public ActionResult Edit(int id)
        {
            var citydata = new SelectList(se.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            City ci = se.Cities.Find(id);
            Driver b = se.Drivers.Find(id);
            return View(b);
        }

        // POST: driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, HttpPostedFileBase f1, Driver c)
        {
            try
            {
                if (file != null)
                {
                    // TODO: Add insert logic here
                    if (file.ContentLength > 0)
                    {
                        c.Driver_Image = file.FileName;
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                        file.SaveAs(_path);

                        se.Entry(c).State = System.Data.Entity.EntityState.Modified;
                        se.SaveChanges();
                       


                    }
                    return RedirectToAction("Index");
                }
            
                if (f1 != null)
                {
                    if (f1.ContentLength > 0)
                    {
                        c.Driver_Licence = f1.FileName;
                        string _FileName = Path.GetFileName(f1.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                        f1.SaveAs(_path);

                        se.Entry(c).State = System.Data.Entity.EntityState.Modified;
                        se.SaveChanges();
                        
                    }
                    return RedirectToAction("Index");



                }
                else
                {
                    se.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    se.SaveChanges();
                    return RedirectToAction("Index");
                }



            }
            catch
            {
                return View();
            }
        }

        // GET: driver/Delete/5
        public ActionResult Delete(int id)
        {
            Driver f = se.Drivers.Find(id);
            se.Drivers.Remove(f);
            se.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: driver/Delete/5
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
