using Model.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicySystem
{
    public class PolicyChangeMessageHandler : IHandleMessages<PolicyChangeRequestMessage>
    {
        public void Handle(PolicyChangeRequestMessage message)
        {
            Console.WriteLine("Policy Change Received Message");

            //BIlling system will do something and then send a message back to the caller
            Bus.Reply<PolicyChangeResponseMessage>(m =>
            {
                m.TrackingNumber = message.TrackingNumber;
            });

            Console.WriteLine("Policy Change Response Sent");

        }
        public IBus Bus { get; set; }
    }
}
