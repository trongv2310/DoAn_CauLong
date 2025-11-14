using DoAn_CauLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CauLong.Controllers
{
    public class HomeController : Controller
    {
        private Model1 data = new Model1();
        public ActionResult Index()
        {
            var sp = data.SanPhams
                        .Include("LoaiSanPham")
                        .ToList();
            return View(sp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}