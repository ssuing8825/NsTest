using Model.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber2
{
    class CustomerAddedEventHandler : IHandleMessages<ICustomerAddedEvent>
    {
        public void Handle(ICustomerAddedEvent message)
        {
            Console.WriteLine("Handling Customer message second subscriber{0}", message.Customer.name);
        }
    }
}
