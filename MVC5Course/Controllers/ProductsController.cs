using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;

namespace MVC5Course.Controllers
{
   
    
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        ProductRepository oProductRepository = RepositoryHelper.GetProductRepository();

        // GET: Products
        public ActionResult Index(string Keyword,string SearchActive, int PageNo = 1)
        {
            var SelectItem = oProductRepository.All().Select(o => (o.Active ?? false).ToString()).Distinct().ToList();
            ViewBag.SearchActive = new SelectList(SelectItem);
            return View(DoSearch(Keyword, SearchActive, PageNo));
        }

        private IPagedList<Product> DoSearch(string Keyword, string SearchActive, int PageNo = 1)
        {
            var datas = oProductRepository.All();
            if (!string.IsNullOrEmpty(Keyword))
            {
                datas = datas.Where(o => o.ProductName.Contains(Keyword));
            }
            if (!string.IsNullOrEmpty(SearchActive))
            {
                bool Active = bool.Parse(SearchActive.ToLower());
                datas = datas.Where(o => o.Active == Active);
            }
            datas = datas.OrderByDescending(o => o.ProductId);
            ViewBag.Keyword = Keyword;
            return datas.ToPagedList(PageNo, 3);
        }

        [HttpPost]
        public ActionResult Index(IList<Product> Products, string Keyword, string SearchActive, int PageNo = 1)
        {
            if (ModelState.IsValid)
            {

                foreach (var oProduct in Products)
                {
                    var OldData = oProductRepository.Find(oProduct.ProductId);
                    OldData.ProductName = oProduct.ProductName;
                    OldData.Price = oProduct.Price;
                    OldData.Active = oProduct.Active;
                    OldData.Stock = oProduct.Stock;
                }
                oProductRepository.UnitOfWork.Commit();
                return RedirectToAction("index");
            }else
            {
                return View(DoSearch(Keyword, SearchActive, PageNo));
            }

         
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = oProductRepository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult ProductOrderLine(int? id)
        {
     
            Product product = oProductRepository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product.OrderLine);
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
                oProductRepository.Add(product);
                oProductRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id,string ww)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = oProductRepository.Find(id);
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
        public ActionResult Edit(int? id , FormCollection form)
        {
            var prod = oProductRepository.Find(id);
            if (this.TryUpdateModel<Product>(prod,new string[] { "ProductName","Stock","Active"}))
            {
                oProductRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = oProductRepository.Find(id);
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
            Product product = oProductRepository.Find(id);
            oProductRepository.Delete(product);
            oProductRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

    }
}
