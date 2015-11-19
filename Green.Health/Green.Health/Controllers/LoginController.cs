using Green.Helth.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class LoginController : BaseController
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
            string prePath = HttpContext.Session["visitpath"] != null ? HttpContext.Session["visitpath"].ToString() : "";

            HttpCookie cookie = new HttpCookie("#555", uid);
            LoginService.CheckLogin("111", "222");
            Response.Cookies.Add(cookie);
            
            if (string.IsNullOrEmpty(prePath))
            {
                return RedirectToAction("ShowInfo", "MaKa");
            }
            {
                return View();
            }
        }
    }
}
