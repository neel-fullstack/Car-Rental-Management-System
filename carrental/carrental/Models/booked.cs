using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carrental.Models
{
    public class booked
    {
        [Key] public int bookId { get; set; }

        public int carid { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string mobilenumber { get; set; }


        
        public string Pickup { get; set; }

        public string pickupaddress { get; set; }

        public string Drop { get; set; }

        public string dropaddress { get; set; }



        [DisplayName("start_date")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime start_date { get; set; }


        [DisplayName("start_time")]
        [DataType(DataType.Time, ErrorMessage = "Time only")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime start_time { get; set; }


        [DisplayName("end_date")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime end_date { get; set; }

        [DisplayName("end_time")]
        [DataType(DataType.Time, ErrorMessage = "Time only")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime end_time { get; set; }


        [DisplayName("BookingDate")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        [DisplayName("BookingDate")]
        [DataType(DataType.Time, ErrorMessage = "Time only")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }


      
        public string No_Of_Days { get; set; }

        public string Bill_Amount { get; set; }

        public string Driver_charge { get; set; }

        public string Net_Amount_Pay { get; set; }

        public string description { get; set; }

        public string driver { get; set; }

        public string payment { get; set; }
    }
}