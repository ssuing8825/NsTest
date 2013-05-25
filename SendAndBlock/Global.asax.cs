using System.Web.Http;
using System.Web.Routing;
using NServiceBus;

namespace SendAndBlock
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Configure.With()
                 .DefaultBuilder()
                 .ForWebApi()
                .DefineEndpointName("SimpleSender")
               .XmlSerializer()
               .UseTransport<NServiceBus.RabbitMQ>()
               .UnicastBus()
               .CreateBus()
               .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
                                     .Install());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}