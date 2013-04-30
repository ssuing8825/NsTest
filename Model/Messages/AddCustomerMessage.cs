using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Messages
{
   public class AddCustomerMessage :IMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
