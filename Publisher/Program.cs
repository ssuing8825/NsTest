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

            INotice[] list = new INotice[1];
            //INotice oneNotice = NServiceBus.MessageInterfaces.MessageMapper.Reflection.MessageMapper().CreateInstance<INotice>();
            INotice one = bus.CreateInstance<INotice>(oneNotice =>
            {
                oneNotice.Id = "123";
                oneNotice.Description = "Can't do something ";
                oneNotice.Severity = "sadfdfs";
            });

            list[0] = one;


            IAddressProperties address = bus.CreateInstance<IAddressProperties>(a =>
            {
                a.AddressId = "123";
                a.AddressLine1 = "asdfasdfa";
                a.CassCode = "sadfdfs";
            });

            list[0] = one;


            
            bus.Publish<IAddressBillingMailingEventSet>(customerCreatedEvent =>
                {
                    customerCreatedEvent.CallingSystem = "This is the calling system";
                    customerCreatedEvent.Notices = list;
                    customerCreatedEvent.Current =  null;
                    customerCreatedEvent.Previous = null;

                });

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
