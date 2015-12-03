using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Green.Health.Web.Framework.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class HttpsRequirementAttribute : FilterAttribute, IAuthorizationFilter
    {
        public HttpsRequirementAttribute(SslRequirement sslRequirement)
        {
            this.SslRequirement = sslRequirement;
        }

        public SslRequirement SslRequirement { get; set; }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new NotImplementedException();
            var currentConnectionSecured = filterContext.HttpContext.Request.IsSecureConnection;
            string url = "";
            switch (SslRequirement)
            {
                case SslRequirement.YES:
                    {
                        if (!currentConnectionSecured)
                        {
                            url = GetThisPageUrl(true, true);
                            filterContext.Result = new RedirectResult(url);
                        }
                    }
                    break;
                case SslRequirement.NO:
                    url = GetThisPageUrl(true, false);
                    filterContext.Result = new RedirectResult(url);
                    break;
                case SslRequirement.NOMATTER:
                    url = GetThisPageUrl(true, false);
                    filterContext.Result = new RedirectResult(url);
                    break;
                default:
                    break;
            }
        }

        public virtual string GetThisPageUrl(bool includeQueryString, bool useSsl)
        {
            string url = string.Empty;
            //if (_httpContext == null || _httpContext.Request == null)
            //    return url;
            string httpHost = ServerVariables("HTTP_HOST");
            if (includeQueryString)
            {
                string storeHost = GetStoreHost(useSsl);
                if (storeHost.EndsWith("/"))
                    storeHost = storeHost.Substring(0, storeHost.Length - 1);
                url = storeHost + HttpContext.Current.Request.RawUrl;
            }
            //else
            //{
            //    if (HttpContext.Current.Request.Url != null)
            //    {
            //        url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
            //    }
            //}

            url = url.ToLowerInvariant();
            return url;
        }

        public virtual string GetStoreHost(bool useSsl)
        {
            string result = "";
            string httpHost = ServerVariables("HTTP_HOST");
            if (!String.IsNullOrEmpty(httpHost))
            {
                if (useSsl)
                {
                    result = "http://localhost:44300";//配置ssl域名
                }
                else
                {
                    result = "http://" + httpHost;
                }
                if (!result.EndsWith("/"))
                    result += "/";
            }
            if (useSsl)
            {
                //Secure URL is not specified.
                //So a store owner wants it to be detected automatically.
                result = result.Replace("http:/", "https:/");
            }
            return result;
        }
        public virtual string ServerVariables(string name)
        {
            string result = string.Empty;

            try
            {
                if (HttpContext.Current.Request == null || HttpContext.Current.Request == null)
                    return result;

                //put this method is try-catch 
                //as described here http://www.nopcommerce.com/boards/t/21356/multi-store-roadmap-lets-discuss-update-done.aspx?p=6#90196
                if (HttpContext.Current.Request.ServerVariables[name] != null)
                {
                    result = HttpContext.Current.Request.ServerVariables[name];
                }
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
