using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Messages
{
    public class PolicyChangeRequestMessage : IMessage
    {
        public Guid TrackingNumber { get; set; }
    }
}
