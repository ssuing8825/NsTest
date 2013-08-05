using Model.Model;
using MongoDB.Bson.Serialization;
using NServiceBus;
using NServiceBus.Saga;


namespace CustomerAccountSystem
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                     .DefaultBuilder()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .MongoPersistence()
                     .MongoSagaPersister();

            Configure.Transactions.Disable();

            //BsonClassMap.RegisterClassMap<IContainSagaData>(cm =>
            //    {
            //        cm.AutoMap();
            //        cm.SetIsRootClass(true);
            //    });

 
            BsonClassMap.RegisterClassMap<UpdatePolicySagaData>(cm =>
            {
                cm.AutoMap();
                //cm.SetIsRootClass(true);
                cm.MapProperty(p => p.TestCustomer);
                cm.MapProperty(p => p.TestCustomerList);
                cm.MapProperty(p => p.ProcessedEventIds);
                cm.MapProperty(p => p.TrackingNumber);
                cm.MapProperty(p => p.Originator);


            });
            ///  [BsonKnownTypes(typeof(IndividualCustomer), typeof(BusinessCustomer))]
            //BsonClassMap.RegisterClassMap<Customer>();
            //BsonClassMap.RegisterClassMap<UpdatePolicySagaData>();

        }
    }
}