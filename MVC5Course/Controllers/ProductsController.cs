using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index()
        {
            var data = repo.All().Take(5).OrderByDescending(p => p.ProductId).ToList();

            ViewData.Model = data;
            return View();

            //return View(data);
            
            //return View(db.Product.OrderByDescending(p=> p.ProductId).Take(100).ToList());
        }

        [HttpPost]
        public ActionResult Index(IList<Prodduct批次更新ViewModel> Products)
        {
            if (ModelState.IsValid)
            {

                foreach (var item in Products)
                {
                    var product = repo.Find(item.ProductId);
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                }
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            var data = repo.All().Take(5).OrderByDescending(p => p.ProductId).ToList();
            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            //Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            //ViewData["OrderLines"] = product.OrderLine.ToList();
            ViewBag.OrderLines = product.OrderLine.ToList();

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                //db.Product.Add(product);
                //db.SaveChanges();

                TempData["ProductCreatDoneMsg"] = "商品新增完成";

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            //Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            //[Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product
            var product = repo.Find(id);
            if (TryUpdateModel<Product>(product, new string[]{
                "ProductId","ProductName","Price","Active","Stock"}))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }


            //if (ModelState.IsValid)
            //{
            //    var db = (FabricsEntities)repo.UnitOfWork.Context;
            //    db.Entry(product).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            //Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            product.IsDeleted = true;
            repo.UnitOfWork.Commit();
            //Product product = db.Product.Find(id);
            ////db.Product.Remove(product);
            //product.IsDeleted = true;
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
