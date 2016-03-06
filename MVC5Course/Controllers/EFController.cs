using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            string szRR = DateTime.Now.ToString("mmss");
            var iProduct = new Product()
            {
                ProductName = "iPhone_" + szRR,
                Price = Convert.ToDecimal(szRR),
                Stock = 5,
                Active = true
            };

            db.Product.Add(iProduct);

            //iProduct.ProductId
            //可直接取iProduct插入的ProductID 


            //db.Product.Add(new Product()
            //{
            //    ProductName = "iPhone",
            //    Price = 1,
            //    Stock = 5,
            //    Active = true
            //});



            //db.SaveChanges();
            //DeBug Demo
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        string entityName = item.Entry.Entity.GetType().Name;
                        throw new Exception(entityName + "欄位異常:" + err.ErrorMessage);
                    }
                }
                throw;
            }



            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    //throw ex;
            //    var allErrors = new List<string>();

            //    foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
            //    {
            //        foreach (DbValidationError err in re.ValidationErrors)
            //        {
            //            allErrors.Add(err.ErrorMessage);
            //        }
            //    }

            //    ViewBag.Errors = allErrors;
            //}


            //var data = db.Product.ToList();

            var pKey = iProduct.ProductId;
            //var data = db.Product.Where(p => p.ProductId == pKey).ToList();

            //排序
            var data = db.Product.OrderByDescending(p => p.ProductId);



            return View(data);
        }


        public ActionResult Detail(int Id)
        {
            //var data = db.Product.Find(Id);
            //var data = db.Product.Where(p => p.ProductId == Id).First();
            var data = db.Product.FirstOrDefault(p => p.ProductId == Id);
            return View(data);
        }
    }
}