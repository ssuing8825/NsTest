using Model.Messages;
using Model.Model;
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
            // test dictionary object  
            var data = new List<string> { "test 1", "test 2" };
            var processedEventIds = new Dictionary<string, List<string>> { { "My test event", data } };

            // test List of objects  
            var customerList = new List<Customer> { new Customer { Id = 22, name = "Justin" }, new Customer { Id = 33, name = "Steve" } };

            var r = new CustomerAndPolicyUpdate { TrackingNumber = Guid.NewGuid(), ProcessedEventIds = processedEventIds, TestCustomer = customerList.First(), TestCustomerList = customerList.ToArray() };
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
