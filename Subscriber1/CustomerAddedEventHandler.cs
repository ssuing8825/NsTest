using Model.Events;
using NServiceBus;
using System;


namespace Subscriber1
{
    class CustomerAddedEventHandler : IHandleMessages<IAddressBillingMailingEventSet>
    {
        public void Handle(IAddressBillingMailingEventSet message)
        {
            Console.WriteLine("Handling Customer message {0}", message.CallingSystem);
        }
    }
}
