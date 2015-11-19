using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult comfirm_order(int id)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["Servers%5FEid"] == null)
            {
                HttpContext.Session.Add("visitpath", HttpContext.Request.Path);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
