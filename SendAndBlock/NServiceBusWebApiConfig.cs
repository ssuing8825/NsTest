using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using NServiceBus;

namespace SendAndBlock
{
    /// <summary>
    /// The NServiceBus Web API config.
    /// </summary>
    public static class NServiceBusWebApiConfig
    {
        /// <summary>
        /// The for Web API configuration.
        /// </summary>
        /// <param name="configure">
        /// The configure.
        /// </param>
        /// <returns>
        /// The <see cref="Configure"/>.
        /// </returns>
        public static Configure ForWebApi(this Configure configure)
        {
            // Register our http controller activator with NSB
            configure.Configurer.RegisterSingleton(
                typeof(IHttpControllerActivator), new NServiceBusHttpControllerActivator());

            // Find every http controller class so that we can register it
            IEnumerable<Type> controllers = Configure.TypesToScan.Where(
                t => typeof(IHttpController).IsAssignableFrom(t));

            // Register each http controller class with the NServiceBus container
            foreach (Type type in controllers)
            {
                configure.Configurer.ConfigureComponent(type, DependencyLifecycle.InstancePerCall);
            }

            //Configure any other dependencies you need here

            // Set the WebApi dependency resolver to use our resolver
            GlobalConfiguration.Configuration.DependencyResolver = new NServiceBusWebApiDependencyResolverAdapter(configure.Builder);

            // Required by the fluent configuration semantics
            return configure;
        }
    }
}