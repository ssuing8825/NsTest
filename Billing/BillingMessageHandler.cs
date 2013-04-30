using Model.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class BillingMessageHandler : IHandleMessages<BillingRequestMessage>
    {
        public void Handle(BillingRequestMessage message)
        {
            Console.WriteLine("Billing Received Message");

            //BIlling system will do something and then send a message back to the caller
            Bus.Reply<BillingResponseMessage>(m =>
            {
                m.TrackingNumber = message.TrackingNumber;
            });

            Console.WriteLine("Billing Response Sent");

        }

        public IBus Bus { get; set; }
    }
}
