using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    class Program
    {
        static void Main(string[] args)
        {

             Configure.With()
                     .DefineEndpointName("CustomerAccountMegaService")
                     .DefaultBuilder()
                     .XmlSerializer()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .InMemorySubscriptionStorage()
                     .UseInMemoryTimeoutPersister()
                     .UnicastBus()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

            Console.Read();

        }
    }
}
