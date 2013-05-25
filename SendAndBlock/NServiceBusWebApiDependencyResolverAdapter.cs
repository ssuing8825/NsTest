
using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using NServiceBus.ObjectBuilder;


namespace SendAndBlock
{
    class NServiceBusWebApiDependencyResolverAdapter : IDependencyResolver
    {
        /// <summary>
        /// The builder.
        /// </summary>
        private readonly IBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NServiceBusWebApiDependencyResolverAdapter"/> class.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        public NServiceBusWebApiDependencyResolverAdapter(IBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            /*No-op*/
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return this.builder.Build(serviceType);
            }

            return null;
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return this.builder.BuildAll(serviceType);
            }

            return new List<object>();
        }
    }
}

