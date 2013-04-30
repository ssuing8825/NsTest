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
            var ncustomer = new Customer { Id = 2, name = "Steve" };
            IBus bus = CreateBusCore();
            bus.Publish<ICustomerAddedEvent>(customerCreatedEvent => customerCreatedEvent.Customer = ncustomer);
            Console.WriteLine("Message Published");
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
