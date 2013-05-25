using Model;
using Model.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new AddCustomerMessage { Name = "Steve" };

            var bus = CreateBusCore();
            //Fully Azync
            bus.Send("Receiver", message).Register(c => Console.WriteLine(((AddCustomerMessageResponse)c.Messages[0]).Id));
           
            Console.WriteLine("Message Sent");

              

        }

        static IBus CreateBusCore()
        {
            return Configure.With()
                     .DefineEndpointName("SimpleSender")
                     .DefaultBuilder()
                     .XmlSerializer()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .UnicastBus()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
                                           .Install());
        }

    }
}
