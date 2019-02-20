using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prac_2_ASP_MVC.Models;
using System.Data;
using System.IO;
using Prac_2_ASP_MVC.ViewModel;


namespace Prac_2_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Report()
        {
         

            ViewModelHardware vm = new ViewModelHardware();

            vm.lowerLimit = new int();
            vm.upperLimit = new int();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Report(ViewModelHardware vm)
        {
            using (HardwareDBEntities db = new HardwareDBEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var list = db.lgproducts.Where(pp =>  pp.prod_qoh >= vm.lowerLimit && pp.prod_qoh <= vm.upperLimit).ToList().Select(rr => new ReportClass
                {
                    prodDesc = rr.prod_descript,
                    prodType = rr.prod_type,
                    prodQOH = Convert.ToInt32(rr.prod_qoh),                    
                });

                vm.results = list.GroupBy(g => g.prodType).ToList();
                vm.chartData = list.GroupBy(g => g.prodType).ToDictionary(g => g.Key, g => g.Sum(v => v.prodQOH));
                TempData["chartData"] = vm.chartData;
          


                return View(vm);
            }
        }
        public ActionResult ChartPage()
        {
      
            var data = TempData["chartData"];
            return View(TempData["chartData"]);
        }

    }
}