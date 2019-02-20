using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prac_2_ASP_MVC.Models;

namespace Prac_2_ASP_MVC.ViewModel
{
    public class ViewModelHardware
    {
        public int lowerLimit { get; set; }
        public int upperLimit { get; set; }

        public lgproduct product { get; set; }
        public List<IGrouping<string, ReportClass>> results { get; set; }
        public Dictionary<string, int> chartData { get; set; }
    }

    public class ReportClass
    {
        public string prodDesc { get; set; }
        public string prodType { get; set; }
        public int prodQOH { get; set; }
    }
}