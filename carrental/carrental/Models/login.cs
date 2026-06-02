using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace carrental.Models
{
    public class login
    {
        [Key] public int loginId { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string mobilenumber { get; set; }
    }
}