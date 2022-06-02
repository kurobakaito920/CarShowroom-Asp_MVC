using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_car_demo2.Areas.admin.Controllers
{
    public class homeAdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("Login2");
            }
            return View();
        }
        public ActionResult Login2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login2(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                Session.Add("UserAdmin","admin");
                return RedirectToAction("Index");
            } 
            else
            {
                return View();
            }
        }
    }
}