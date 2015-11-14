using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class MaKaController : Controller
    {
        //
        // GET: /MaKa/

        public ActionResult ShowInfo()
        {
            if (Request.Cookies.Get("#555") != null)
            {
                ViewBag.uid = Request.Cookies.Get("#555").Value.ToString();
            }
            return View();
        }

    }
}
