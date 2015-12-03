using Green.Health.Entity;
using Green.Health.Models;
using Green.Health.Service;
using Green.Health.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Green.Health.Controllers
{
    public class LoginController : BaseController
    {
        private ILoginService loginService;

        private ICustomerService authService;

        public LoginController(ILoginService mloginservice, ICustomerService authService)
        {
            this.loginService = mloginservice;
            this.authService = authService;
        }

        //
        // GET: /Login/
        [HttpsRequirement(SslRequirement.YES)]
        public ActionResult Index(LoginModel model)
        {
            return View("LogIn", model);
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel model, string rtnUrl)
        {
            string uid = model.UserName;
            string pwd = model.Pwd;
            LoginResult result = loginService.CheckLogin(uid, pwd);
            Customer customer = authService.GetCustomer(uid);
            switch (result)
            {
                case LoginResult.Success:
                    loginService.SingIn(customer);
                    rtnUrl = HttpUtility.UrlDecode(rtnUrl);
                    if (!string.IsNullOrEmpty(rtnUrl))
                    {
                        return Redirect(rtnUrl);
                    }
                    else
                    {
                        return RedirectToAction("ShowInfo", "Maka");
                    }
                case LoginResult.NotExist:
                    ModelState.AddModelError("UserName", "用户名不存在！");
                    break;
                case LoginResult.PwdError:
                    ModelState.AddModelError("Pwd", "密码输入错误！");
                    break;
                case LoginResult.IsNotActive:
                    ModelState.AddModelError("UserName", "用户未激活！");
                    break;
                default:
                    break;
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            loginService.SingOut();
            return RedirectToAction("ShowInfo", "Maka");
        }
    }
}
