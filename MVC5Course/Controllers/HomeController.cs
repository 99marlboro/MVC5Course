using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [紀錄Action的執行時間Attribute]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [共用的ViewBag資料共享部份HomeController動作方法]
        public ActionResult About()
        {
            //throw new Exception("AAA");
            // TODO:test
            //ViewBag.Message = "Your application description page.";
            // HACK:中文
            return View();

           
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //可以自定義ERROR PAGE
        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        [HandleError(ExceptionType = typeof(SqlException), View = "ErrorArgument")]
        public ActionResult ErrorTest(string e)
        {
            if (e == "1")
            {
                throw new Exception("Error 1");
            }
            if (e == "2")
            {
                throw new ArgumentException("Error 2");
            }
            return Content("No Error");
        }

        public ActionResult Razor()
        {
            int[] data = { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}