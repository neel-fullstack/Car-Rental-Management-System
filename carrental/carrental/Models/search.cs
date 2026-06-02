using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carrental.Models
{
    public class search
    {
        [Key] public int searchId { get; set; }

        public string Pickup { get; set; }

        public string Drop { get; set; }


        [DisplayName("start_date")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime start_date { get; set; }


        [DisplayName("start_time")]
        [DataType(DataType.Time, ErrorMessage = "Time only")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime start_time { get; set; }
    }
}