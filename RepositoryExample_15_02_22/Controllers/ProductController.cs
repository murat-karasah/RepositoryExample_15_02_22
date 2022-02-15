using RepositoryExample_15_02_22.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryExample_15_02_22.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository prep = new ProductRepository();
        ProductModel pm = new ProductModel();
        // GET: Product
        public ActionResult Index()
        {
            pm.pList = prep.Listele();
            return View(pm);
        }

        public ActionResult Detay(int id)
        {
            pm.Products = prep.Bul(id);
            return View(pm);
        }

        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(ProductModel pm)
        {
            if (ModelState.IsValid)
            {
                Products p = new Products();
                p.ProductID = pm.Products.ProductID;
                p.ProductName = pm.Products.ProductName;
                p.UnitPrice = pm.Products.UnitPrice;
                prep.Ekle(p);
                prep.Guncel();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}