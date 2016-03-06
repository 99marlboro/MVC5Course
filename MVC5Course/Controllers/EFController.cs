using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index(bool? IsActive, string keyword)
        {
            #region 新增資料
            string szRR = DateTime.Now.ToString("mmss");
            var iProduct = new Product()
            {
                ProductName = "iPhone_" + szRR,
                Price = Convert.ToDecimal(szRR),
                Stock = 5,
                Active = true
            };
            db.Product.Add(iProduct);
            //SaveChanges();

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

            #endregion

            #region 顯示資料
            //var data = db.Product.ToList();
            //var pKey = iProduct.ProductId;
            //var data = db.Product.Where(p => p.ProductId == pKey).ToList();
            //排序
            //var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
            //var data = db.Product.Where(p => p.Active.HasValue ? p.Active.Value : true).Take(5);
            //var data = db.Product.Where(p => p.Active.HasValue ? p.Active.Value == IsActive : true).Take(5);

            //條件
            var data = db.Product.OrderBy(p => p.ProductId).Take(10).AsQueryable();

            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : true).Take(5);
            }           
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            ////更新
            //foreach (var item in data)
            //{
                
            //}
            //db.Database.ExecuteSqlCommand("SQL COMMAND");
                       
            #endregion

            return View(data);
        }


        public ActionResult Detail(int Id)
        {
            #region Detail
            //var data = db.Product.Find(Id);
            //var data = db.Product.Where(p => p.ProductId == Id).First();
            var data = db.Product.FirstOrDefault(p => p.ProductId == Id);
            #endregion

            return View(data);
            
        }


        public ActionResult Delete(int Id)
        {
            #region 刪除資料
            var iPorduct = db.Product.Find(Id);
            //var ol = db.OrderLine.Where(p => p.ProductId == Id);
            //db.OrderLine.Remove(ol);
            //foreach (var ol in iPorduct.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(ol);
            //}
            db.OrderLine.RemoveRange(iPorduct.OrderLine);// 如果DB有一對多的關聯，則可使用此語法進行刪除
            db.Product.Remove(iPorduct);
            SaveChanges();
            #endregion

            return RedirectToAction("Index");
            
        }

        private void SaveChanges()
        {
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
                        throw new Exception(entityName + "類型驗證失敗:" + err.ErrorMessage);
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

        }

        public ActionResult QueryPlan(int num = 10)
        {
            //var data = db.Product.OrderBy(p => p.ProductId).Take(10).AsQueryable();
            //var data = db.Product.Include("OrderLine").OrderBy(p => p.ProductId).Take(10).AsQueryable();
            var data = db.Product.Include(t => t.OrderLine).OrderBy(p => p.ProductId).Take(10).AsQueryable();

            //SQL statement直接下
//            var data = db.Database.SqlQuery<Product>(@"
//                SELECT top 100 * FROM dbo.Product P
//                LEFT JOIN OrderLine O ON (P.ProductId = O.ProductId)
//                WHERE P.ProductId = @p0 and P.ProductNume like @p1
//                ", num, keyword);

            //執行SP
            //db.usp_Fabrics(10, 10);
            return View(data);
        }
    }
}