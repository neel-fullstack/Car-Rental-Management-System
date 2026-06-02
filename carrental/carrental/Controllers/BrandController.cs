using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class BrandController : Controller
    {
        carrentalEntities se = new carrentalEntities();
        // GET: Brand
        public ActionResult Index()
        {
            List<Brand > lst = se.Brands.ToList();
            return View(lst);
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Brand c)
        {
            try
            {
                // TODO: Add insert logic here

                if (file.ContentLength > 0)
                {
                    c.brand_logo = file.FileName;
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    file.SaveAs(_path);
                    se.Brands.Add(c);
                    se.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();


            }
            catch(Exception ex)
            {
                ViewBag.Message = "File upload failed!!" + ex.Message;
                return View();
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            Brand b = se.Brands.Find(id);
            return View(b);
           
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, Brand c)
        {
            try
            {

                if (file!=null)
                // TODO: Add update logic here
                {
                    if (file.ContentLength > 0)
                    {
                        c.brand_logo = file.FileName;
                        string _fileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Upload"), _fileName);
                        file.SaveAs(_path);

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

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            Brand f = se.Brands.Find(id);
            se.Brands.Remove(f);
            se.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Brand/Delete/5
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
