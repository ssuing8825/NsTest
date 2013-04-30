using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Model;
using Model.Messages;

namespace Receiver
{
    public class AddCustomerHandler : IHandleMessages<AddCustomerMessage>
    {
        public void Handle(AddCustomerMessage message)
        {
            Console.WriteLine("Message Recieved");
        }
    }
}
