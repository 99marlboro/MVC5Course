using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    //[Authorize]
    public abstract class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
                //this.Redirect("/").ExecuteResult(this.ControllerContext);
            }
        }

        //抽象不可直接被執行
        protected ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult DEBUG()
        {
            return Content("DEBUG");
        }
    }
}