using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _62.Multiple_Model_Data_in_Single_View.Models
{
    public class MultiModelData
    {
        public List<student> my_students { get; set; }
        public List<teacher> my_teachers { get; set; }

    }
}