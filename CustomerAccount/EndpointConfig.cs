using NServiceBus;


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
        }
    }
}