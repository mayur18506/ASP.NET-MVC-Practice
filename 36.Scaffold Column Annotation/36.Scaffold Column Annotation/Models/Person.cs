using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _36.Scaffold_Column_Annotation.Models
{
    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }

        [ScaffoldColumn(false)]
        public string contact { get; set; }

        [ScaffoldColumn(false)]
        public string Address { get; set; }

    }
}