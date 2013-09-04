using Model.Events;
using Model.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Exceptions;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            IBus bus = CreateBusCore();

            int i = 0;
            while (i < 5000)
            {
                if (PublishAddressBillingMailingEventSet(bus, i))
                {
                    Console.WriteLine("Published event " + i);
                    i++;
                }
                else
                {
                    Console.WriteLine("Publish for event '" + i + "' previously failed; retrying...");
                }
            }
        }

        static bool PublishAddressBillingMailingEventSet(IBus bus, int callingSystemId)
        {
            try
            {
                bus.Publish<IAddressBillingMailingEventSet>(customerCreatedEvent =>
                {
                    customerCreatedEvent.CallingSystem = callingSystemId.ToString();
                    System.Threading.Thread.Sleep(100);
                });
                return true;
            }
            catch (OperationInterruptedException ex)
            {
                // todo: log that a RabbitMQ cluster node is down

                // wait for cluster to failover to mirrored node
                Console.WriteLine("RabbitMQ node is down; waiting for failover node...");
                System.Threading.Thread.Sleep(5000);
                return false;
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
