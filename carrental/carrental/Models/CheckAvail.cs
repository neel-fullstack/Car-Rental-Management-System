using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carrental.Models
{
    public class CheckAvail
    {
        public string Pickup { get; set; }

        public string Drop { get; set; }

        //[ValidateDateRange(FirstDate = Convert.ToDateTime("01/10/2008"), SecondDate = Convert.ToDateTime("01/12/2008"))]
//public DateTime StartWork { get; set; }
  //      [Range(typeof(DateTime), DateTime.Now, DateTime.Now.AddDays(15) )]
          public DateTime Date { get; set; }
          public string Time{ get; set; }

    }
}