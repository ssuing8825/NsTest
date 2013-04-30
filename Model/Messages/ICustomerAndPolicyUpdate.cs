using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Messages
{
   public interface ICustomerAndPolicyUpdate : IMessage
    {
         Guid TrackingNumber { get; set; }
    }
}
