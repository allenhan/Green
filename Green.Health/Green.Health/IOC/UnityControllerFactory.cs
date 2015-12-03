using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Green.Health.IOC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        readonly IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
            var controllerTypes =
               from t in Assembly.GetExecutingAssembly().GetTypes()
               where typeof(IController).IsAssignableFrom(t)
               select t;
            foreach (var t in controllerTypes)
                container.RegisterType(t);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;
            return (IController)container.Resolve(controllerType);
        }
    }
}
