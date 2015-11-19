using Green.Health.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    [AuthorizeFilter]
    public abstract class BaseController : Controller
    {
        
        public BaseController() {
            if (System.Web.HttpContext.Current.Request.Cookies["Servers%5FEid"] != null)
            {
 
            }
        }
    }
}
