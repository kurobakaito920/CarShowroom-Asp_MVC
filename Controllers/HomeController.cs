using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_car_demo2.Models;
namespace web_car_demo2.Controllers
{
    public class HomeController : Controller
    {
        private JinzuaCarShopEntities db = new JinzuaCarShopEntities();
        public ActionResult Index()
        { 
            return View(db.products.ToList());
        }
    }
}