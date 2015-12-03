using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green.Health.IOC
{
    public class UnityConfigurator
    {
        public static IUnityContainer CreateContainer()
        {
            IUnityContainer parentContaier = new UnityContainer();
            IUnityContainer orderContainer = parentContaier.CreateChildContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(orderContainer, "containerOne");
            return orderContainer;
        }
    }
}
