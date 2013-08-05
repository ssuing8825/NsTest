using Model.Model;
using NServiceBus.Saga;
using System;
using System.Collections.Generic;

namespace CustomerAccountSystem
{
    public class UpdatePolicySagaData : IContainSagaData
    {
        // the following properties are mandatory
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        // all other properties you want persisted
        public Guid TrackingNumber { get; set; }

        // complex sample objects  
        public Dictionary<string, List<string>> ProcessedEventIds { get; set; }

        public Customer TestCustomer { get; set; }

        public Customer[] TestCustomerList { get; set; }

    }
}
