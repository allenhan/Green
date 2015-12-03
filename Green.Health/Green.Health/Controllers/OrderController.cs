using Green.Health.Service;
using Green.Health.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Green.Health.Controllers
{
    public class OrderController : BaseController
    {
        public ILoginService _loginService;

        public OrderController(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        public ActionResult comfirm_order(int id = 1)
        {
            //如果没有登录，跳转到登录页面
            if (_loginService.GetCustomer() == null)
            {
                string url = HttpUtility.UrlEncode(HttpContext.Request.Url.AbsolutePath);
                return RedirectToAction("Index", "Login", new { rtnUrl = HttpContext.Request.Url });
            }
            return View();
        }
    }
}
