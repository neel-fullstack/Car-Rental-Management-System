using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carrental.Models;

namespace carrental.Controllers
{
    public class user2Controller : Controller
    {
        // GET: user2
        carrentalEntities dc = new carrentalEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FAQ()
        {
            List<FAQ> lst = dc.FAQs.ToList();

            return View(lst);
        }
    }
}