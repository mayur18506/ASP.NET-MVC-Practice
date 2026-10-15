using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _39.Cookies.Models
{
    public class User
    {
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
    }
}