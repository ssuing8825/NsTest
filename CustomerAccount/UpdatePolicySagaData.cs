using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAccountSystem
{
    public class UpdatePolicySagaData : IContainSagaData
    {
        // the following properties are mandatory
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }

        // all other properties you want persisted
        public virtual Guid TrackingNumber { get; set; }
    }
}
