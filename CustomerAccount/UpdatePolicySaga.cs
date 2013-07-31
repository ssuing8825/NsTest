using Model.Messages;
using NServiceBus;
using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAccountSystem
{
   public  class UpdatePolicySaga: Saga<UpdatePolicySagaData>,
        IAmStartedByMessages<CustomerAndPolicyUpdate>,
        IHandleMessages<BillingResponseMessage>,
        IHandleMessages<PolicyChangeResponseMessage>
    {
       public override void ConfigureHowToFindSaga()
       {
           
           ConfigureMapping<CustomerAndPolicyUpdate>(s => s.TrackingNumber).ToSaga(m => m.TrackingNumber);
           ConfigureMapping<BillingRequestMessage>(s => s.TrackingNumber).ToSaga(m => m.TrackingNumber);
           ConfigureMapping<PolicyChangeRequestMessage>(s => s.TrackingNumber).ToSaga(m => m.TrackingNumber);
           // Notice that we have no mappings for the OrderAuthorizationResponseMessage message. This is not needed since the HR
           // endpoint will do a Bus.Reply and NServiceBus will then automatically correlate the reply back to
           // the originating saga
           Console.WriteLine("Configuring Saga" );
       }


       public void Handle(CustomerAndPolicyUpdate message)
       {
           Console.WriteLine("Received CustomerAndPolicyUpdate Message: " + message);

           //Store Saga Data 
           this.Data.TrackingNumber = message.TrackingNumber;

           //Tell the billing System to do somethign

           var billingMessage = new Model.Messages.BillingRequestMessage { TrackingNumber = message.TrackingNumber };

           Bus.Send("Billing",billingMessage);

           Console.WriteLine("Billing Message Sent" + message);

          
       }

       public void Handle(BillingResponseMessage message)
       {
           Console.WriteLine("Received Billing Response : " + message);

           //Raise the policy CHange request
           //Store Saga Data 
           this.Data.TrackingNumber = message.TrackingNumber;

           //Tell the Policy System to do somethign

           var policyChangeMessage = new Model.Messages.PolicyChangeRequestMessage { TrackingNumber = message.TrackingNumber };

           Bus.Send("PolicySystem", policyChangeMessage);

           Console.WriteLine("Policy Change Message Sent" + message);
       }

       public void Handle(PolicyChangeResponseMessage message)
       {
           Console.WriteLine("Received Response From Policy: " + message);
       }
    }
}
