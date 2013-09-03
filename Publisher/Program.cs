using Model.Events;
using Model.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            IBus bus = CreateBusCore();

            for (int i = 0; i < 5000; i++)
            {
                 bus.Publish<IAddressBillingMailingEventSet>(customerCreatedEvent =>
                {
                    customerCreatedEvent.CallingSystem =  i.ToString();
                    System.Threading.Thread.Sleep(100);
                });

            Console.WriteLine(i); 
            }
          
        }
        static IBus CreateBusCore()
        {
            return Configure.With()
                     .DefineEndpointName("NSTest.Pub")
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
