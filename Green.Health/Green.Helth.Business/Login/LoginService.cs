using Green.Health.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Green.Health.Service
{
    public class LoginService : ILoginService
    {
        private Customer cacheCustomer;
        private ICustomerService authService;

        public LoginService(ICustomerService authService)
        {
            this.authService = authService;
        }

        public LoginResult CheckLogin(string loging, string pwd)
        {
            return authService.CheckCustomer(loging, pwd);
        }

        public bool SingIn(Customer cusomer)
        {
            var now = DateTime.UtcNow.ToLocalTime();
            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                cusomer.UserName,
                now,
                now.Add(TimeSpan.FromMinutes(1)),
                false,
                cusomer.UserName,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
            cacheCustomer = cusomer;
            return true;
        }

        public Customer GetCustomer()
        {
            try
            {
                if (this.cacheCustomer != null)
                    return this.cacheCustomer;
                if (HttpContext.Current == null || HttpContext.Current.Request == null || !(HttpContext.Current.Request.IsAuthenticated) || !(HttpContext.Current.User.Identity is FormsIdentity))
                    return null;

                var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                var customer = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
                this.cacheCustomer = customer;
                return this.cacheCustomer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SingOut()
        {
            FormsAuthentication.SignOut();
            cacheCustomer = null;
        }

        public virtual Customer GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var username = ticket.UserData;

            if (String.IsNullOrWhiteSpace(username))
                return null;
            var customer = authService.GetCustomer(username);
            cacheCustomer = customer;
            return cacheCustomer;
        }
    }
}
