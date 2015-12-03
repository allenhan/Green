using Green.Health.Entity;
using Green.Health.Models;
using Green.Health.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class CommonController : Controller
    {
       public ILoginService _loginService;

       public CommonController(ILoginService loginService) 
        {
            this._loginService = loginService;
        }

        public ActionResult headlink()
        {
            CommonModel cm = new CommonModel();
            cm.Customer = _loginService.GetCustomer();
            return PartialView("_Head",cm);
        }

    }
}
