using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Mvc;
using carrental.Models;
using Razorpay.Api;

namespace carrental.Controllers
{
    public class userController : Controller
    {
        //Card No
        //5267 3181 8797  5449
        //Expiry
        //05/25
        //CVV
        //123
        // GET: user
        public userController()
        {
            List<car_category> lst = dc.car_category.ToList();
            ViewData["car_category"] = lst;
            List<City> city = dc.Cities.ToList();
            ViewData["City"] = city;
            List<car_type> car = dc.car_type.ToList();
            ViewData["car_type"] = car;
            List<service_category> ser= dc.service_category.ToList();
            ViewData["service_category"] = ser;
        }
        carrentalEntities dc = new carrentalEntities();
        public ActionResult Index()
        {
           List<car_type> lst = dc.car_type.ToList().Take(6).ToList();
          //  ViewData["car_category"] = lst;
            return View(lst);
        }
        public ActionResult mylist()
        {
            List<car_type> lst = dc.car_type.ToList().Take(6).ToList();
            //  ViewData["car_category"] = lst;
            return View("Index",lst);
        }


        public ActionResult carlisting(int? id)
        {

           /* List<car_category> lst = dc.car_category.ToList();
            ViewData["car_category"] = lst;*/
            List<car_type> lst2;
            if (id==null)
                lst2 = dc.car_type.ToList();
            else
                        lst2 = dc.car_type.Where(d => d.Category_id == id).ToList();

          
            return View(lst2);
        }

        public ActionResult cardetails(int id)
        {

            car_type c = dc.car_type.Find (id);
            return View(c);

            //List<City> cities;
            ViewData["city"] = dc.Cities.ToList();
            //   return View(cities);
            ViewData["car"] = dc.car_type.ToList();
        }

        [HttpPost]
        public ActionResult cardetails(car_type ca, FormCollection collection)
        {

            //var id2= ca.car_Id;
            //return RedirectToAction("booked", new { id = id2 });
            Session["carid"] = ca.car_Id;
            Session["status"] = "booking";
            //var pickup = collection["Pickup"];
            //var Drop = collection["Drop"];
            //DateTime start_date = DateTime.Parse(collection["start_date"]);
            //DateTime end_date = DateTime.Parse(collection["end_date"]);
            //List<booking> lst2 = dc.bookings.Where(d => d.car_id == ca.car_Id && d.start_time>=start_date && d.end_date<=end_date).ToList();
            //if (lst2.Count > 0)
            //{
            //    ViewBag.Msg = "This Car Not Available";
            //    return View("carlisting");
            //}
            if (Session["user"] == null)
            { 
                return RedirectToAction("userlogin");
            }
            else
            { 
                return RedirectToAction("booked", new { id = ca.car_Id });
            }

        }


        public ActionResult userregister()
        {
            return View();
        }

        // POST: admin_register/Create
        [HttpPost]
        public ActionResult userregister(User u)
        {
            try
            {
                // TODO: Add insert logic here
              
                {



                    dc.Users.Add(u);
                    dc.SaveChanges();
                    Session["user"]=u;
                    if (Session["status"] == null)
                    {
                       return RedirectToAction("userlogin");
                    }
                    else if (Session["status"].ToString() == "booking")
                    {
                        var id2 = Session["carid"];
                        return RedirectToAction("booked", new { id = id2 });
                    }
                    else
                    {
                        return RedirectToAction("userlogin");
                    }

//                    return RedirectToAction("userlogin");
                }
              


            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!" + ex.Message;
                return View();
            }
        }


        public ActionResult userlogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userlogin(User u)
        {
            try
            {
                // TODO: Add update logic here
                string username = u.user_name;
                string email = u.user_emailid;
                string password = u.user_password;
                var res = dc.Users.Where(er => er.user_emailid == u.user_emailid && er.user_password == u.user_password);
                if (res.ToList().Count > 0)
                {
                    Session["user"] = res.First();
                    if (Session["status"] == null)
                    {
                        return RedirectToAction("mylist","user");
                    }
                    else if (Session["status"].ToString() == "booking")
                    {
                        var id2 = Session["carid"];
                        return RedirectToAction("booked", new { id = id2 });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    //return View("Index");

                    //var id2= ca.car_Id;
                    //return RedirectToAction("booked", new { id = id2 });
                }

                else
                    return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult mybooking()
        {
            User ur = (User)Session["user"];

            List<booking> lst = dc.bookings.Where(db => db.user_id == ur.user_Id).ToList();
            return View(lst);

        }


        public ActionResult brand()
        {

            List<Brand> lst = dc.Brands.ToList();
            return View(lst);
        }


     
        public ActionResult booked( int id)
        {
            car_type c = dc.car_type.Find(id);
            ViewData["cartype"]=c;
            booked bb = new booked();
            
            User u = (User)Session["user"];
            bb.firstname = u.user_name;
            bb.lastname = u.user_lastname;
            bb.email = u.user_emailid;
            bb.mobilenumber = u.user_contact;

            bb.carid = c.car_Id;
            return View("CreateBooking",bb);

        }
        [HttpPost]
        public ActionResult booked(booked b)
        {
            if (b.payment == "cash on drop")
            {
                /*User u = new User();
                u.user_name = b.firstname;
                u.user_lastname = b.lastname;
                u.user_emailid = b.email;
                u.user_contact = b.mobilenumber;
                dc.Users.Add(u);
                dc.SaveChanges();*/

                User u = (User)Session["user"];

                booking bk = new booking();
                bk.pickuplocation = b.Pickup;
                bk.pickupaddress = b.pickupaddress;
                bk.droplocation = b.Drop;
                bk.dropaddress = b.dropaddress;
                bk.start_date = b.start_date;
                bk.start_time = b.start_time;
                bk.end_date = b.end_date;
                bk.end_time = b.end_time;
                bk.description = b.description;
                bk.with_without_driver = b.driver;
                bk.mode_of_payment = b.payment;
                bk.no_of_days = b.No_Of_Days;
                bk.bill_amount = b.Bill_Amount;
                bk.driver_charge = b.Driver_charge;
                bk.net_amount_pay = b.Net_Amount_Pay;
                bk.booking_date = DateTime.Today;
                bk.car_id = b.carid;
                bk.offer_id = null;
                bk.user_id = u.user_Id;


                dc.bookings.Add(bk);
                dc.SaveChanges();
                return RedirectToAction("Billinvoice", "user", new { bid = bk.booking_Id });
            }
            else
            {
                try
                {
                    Session["bookdata"] = b;

                    //String redirectUrl = "";

                    ////Mention URL to redirect content to paypal site
                    //redirectUrl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();
                    //redirectUrl += "&amount=" + Int16.Parse( b.Net_Amount_Pay);
                    //redirectUrl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"];
                    //redirectUrl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"];
                    //ViewBag.actionurl = redirectUrl;

                    //Response.Redirect(redirectUrl);

                    return RedirectToAction("OnlinePayment", "User", new { amount = b.Net_Amount_Pay });
                    // return View();
                    //  return RedirectToAction("paypal");
                }
                catch
                {
                    return View();
                }



            }

         
        }


        public ActionResult OnlinePayment(int amount)
        {
            var netamount = amount * 100;
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", netamount); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");

            string key = "rzp_test_avNsy3tB1x5rTf";
            string secret = "WvgxrlzaTSFEKbIMuT9PINGr";

            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.orderId = order["id"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult OnlinePayment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)

        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id); // this amount should be same as transaction amount
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);
            try
            {
                Utils.verifyPaymentSignature(attributes);
                return RedirectToAction("success");
            }
            catch (Exception ex)
            {
                return View("failure");
            }

            //return View();
        }

        public ActionResult success()

        {
            booked b = (booked)Session["bookdata"];

            /*            User u = new User();
                        u.user_name = b.firstname;
                        u.user_lastname = b.lastname;
                        u.user_emailid = b.email;
                        u.user_contact = b.mobilenumber;
                        dc.Users.Add(u);
                        dc.SaveChanges();
            */
            User u = (User)Session["user"];

            booking bk = new booking();
            bk.pickuplocation = b.Pickup;
            bk.pickupaddress = b.pickupaddress;
            bk.droplocation = b.Drop;
            bk.dropaddress = b.dropaddress;
            bk.start_date = b.start_date;
            bk.start_time = b.start_time;
            bk.end_date = b.end_date;
            bk.end_time = b.end_time;
            bk.description = b.description;
            bk.with_without_driver = b.driver;
            bk.mode_of_payment = b.payment;
            bk.no_of_days = b.No_Of_Days;
            bk.bill_amount = b.Bill_Amount;
            bk.driver_charge = b.Driver_charge;
            bk.net_amount_pay = b.Net_Amount_Pay;
            bk.booking_date = DateTime.Now;
            bk.car_id = b.carid;
            bk.offer_id = null;
            bk.user_id = u.user_Id;


            dc.bookings.Add(bk);
            dc.SaveChanges();
            return RedirectToAction("Billinvoice", "user", new { bid = bk.booking_Id });
        }
        public ActionResult failure()

        {
            return View();
        }
            public ActionResult Billinvoice(int bid)

        {   

            booking book =dc.bookings.Where(bo => bo.booking_Id== bid).Take(1).First();
           
            return View(book);

        }
      


        [HttpPost]
        public ActionResult search(FormCollection collection)
        {
            var pickcity = collection["Pickup"];
            List<car_type> car = dc.car_type.Where(c=>c.City.city_name==pickcity ).ToList();
            //ViewData["car_type"] = car;

        //    dc.SaveChanges();
            return View("carlisting", car);
        }

        //Business / Corporates</a>
        //Long Term lease Car Rental
        //Events - Delegations
        //Wedding Car Rentals
        public ActionResult bussinesservices()
        {
            var citydata = new SelectList(dc.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            var servicedata = new SelectList(dc.service_category.ToList(), "serviceId", "servicename");
            ViewData["service_category"] = servicedata;
            return View();
        }

        [HttpPost]
        public ActionResult bussinesservices(service s)
        {
            dc.services.Add(s);
            dc.SaveChanges();
            return RedirectToAction("bussinesservices");
        }



        public ActionResult LongTermleaseCarRental()
        {
            var citydata = new SelectList(dc.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            var servicedata = new SelectList(dc.service_category.ToList(), "serviceId", "servicename");
            ViewData["service_category"] = servicedata;
            return View();
        }

        [HttpPost]
        public ActionResult LongTermleaseCarRental(service s)
        {
            dc.services.Add(s);
            dc.SaveChanges();
            return RedirectToAction("LongTermleaseCarRental");
        }



        public ActionResult EventsDelegations()
        {
            var citydata = new SelectList(dc.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            var servicedata = new SelectList(dc.service_category.ToList(), "serviceId", "servicename");
            ViewData["service_category"] = servicedata;
            return View();
        }

        [HttpPost]
        public ActionResult EventsDelegations(service s)
        {
            dc.services.Add(s);
            dc.SaveChanges();
            return RedirectToAction("EventsDelegations");
        }



        public ActionResult WeddingCarRentals()
        {
            var citydata = new SelectList(dc.Cities.ToList(), "city_Id", "city_name");
            ViewData["city"] = citydata;
            var servicedata = new SelectList(dc.service_category.ToList(), "serviceId", "servicename");
            ViewData["service_category"] = servicedata;
            return View();
        }

        [HttpPost]
        public ActionResult WeddingCarRentals(service s)
        {
            dc.services.Add(s);
            dc.SaveChanges();
            return RedirectToAction("WeddingCarRentals");
        }
        public ActionResult contact()
        {
            return View();
        }

            [HttpPost]
        public ActionResult contact(contact c)
        {
            dc.contacts.Add(c);
            dc.SaveChanges();
            return RedirectToAction("mylist");
        }

        public ActionResult about()
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