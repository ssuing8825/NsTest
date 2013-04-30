using Model.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = CreateBus();

            var message = CreateMessage();

            bus.Send("CustomerAccountSystem", message); 
            Console.WriteLine("Message Sent!");
            Console.ReadLine();


        }

        static CustomerAndPolicyUpdate CreateMessage()
        {
            var r = new CustomerAndPolicyUpdate { TrackingNumber = Guid.NewGuid() };
            return r;
        }
        static IBus CreateBus()
        {
            return Configure.With()
                     .DefineEndpointName("CustomerAccountMegaService")
                     .DefaultBuilder()
                     .XmlSerializer()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .InMemorySubscriptionStorage()
                     .UseInMemoryTimeoutPersister()
                     .UnicastBus()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
                                           .Install());
        }

    }
}
