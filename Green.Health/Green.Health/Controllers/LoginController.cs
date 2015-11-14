using Green.Helth.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(FormCollection collection)
        {
            string uid = collection["userno"].ToString();
            string pwd = collection["passwd"].ToString();
            HttpCookie cookie = new HttpCookie("#555", uid);
            LoginService.CheckLogin("111", "222");
            Response.Cookies.Add(cookie);
            return RedirectToAction("ShowInfo", "MaKa");
        }
    }
}
