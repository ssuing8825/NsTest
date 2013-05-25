using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SendAndBlock
{
    public class NServiceBusHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return GlobalConfiguration.Configuration.Services.GetService(controllerType) as IHttpController;
        }
    }
}