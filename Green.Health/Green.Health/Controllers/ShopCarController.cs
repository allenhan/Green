using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class ShopCarController : Controller
    {
        //
        // GET: /ShopCar/

        public ActionResult AddProduct()
        {
            return View();
        }
    }
}
