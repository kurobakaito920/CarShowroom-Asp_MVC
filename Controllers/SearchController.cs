using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using web_car_demo2.Models;

namespace web_car_demo2.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private JinzuaCarShopEntities db = new JinzuaCarShopEntities();
        public ActionResult Index(string search)
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category).Include(p => p.stock);
            if (!String.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                products = products.Where(b => b.product_name.ToLower().Contains(search));
            }
            return View(products.ToList());
        }
    }
}