using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;
using Microsoft.Win32;

namespace carrental.Controllers
{
    public class admin_registerController : Controller
    {
        carrentalEntities se = new carrentalEntities();

        // GET: admin_register
        public ActionResult Index()
        {
            return View();
        }

        // GET: admin_register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin_register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin_register/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Admin_register ar)
        {
            try
            {
                // TODO: Add insert logic here
                if (file.ContentLength > 0)
                {
                    ar.admin_profilepic = file.FileName;
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload"), _FileName);
                    file.SaveAs(_path);
                    se.Admin_register.Add(ar);
                    se.SaveChanges();
                    return RedirectToAction("login");
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();

               
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!" + ex.Message;
                return View();
            }
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin_register l)
        {
            try
            {
                // TODO: Add update logic here
                string username = l.admin_name;
                string password = l.admin_password;
                var res = se.Admin_register.Where(er => er.admin_name == l.admin_name && er.admin_password == l.admin_password);
                if(res.ToList().Count > 0)
                {
                    Session["user"] = l.admin_name;
                    HttpCookie ck = new HttpCookie("user", username);
                    ck.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(ck);
                    return RedirectToAction("Home");
                }

                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

         public ActionResult Home()
        {
            ViewData["totalbook"] = se.bookings.ToList().Count();
            ViewData["totaluser"] = se.Users.ToList().Count();
            ViewData["totalcontact"] = se.contacts.ToList().Count();
            var dt = DateTime.Parse(DateTime.Today.ToShortDateString());
            
            ViewData["todaybooking"] = se.bookings.Where(c => c.booking_date == dt).ToList();
            return View();
        }

        // GET: admin_register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin_register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: admin_register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin_register/Delete/5
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
