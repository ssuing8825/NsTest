using Model.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Messages
{
    public class CustomerAndPolicyUpdate : IMessage
    {
        public Guid TrackingNumber { get; set; }
        // test complex objects  
        public Dictionary<string, List<string>> ProcessedEventIds { get; set; }

        public Customer TestCustomer { get; set; }

        public Customer[] TestCustomerList { get; set; }


    }
}
