using NServiceBus;
using NHibernate.Cfg;

namespace CustomerAccountSystem
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<NServiceBus.RabbitMQ>, IWantCustomInitialization
    {
        public void Init()
        {
            //Configure.With()
            //      .DefaultBuilder()
            //       .UseNHibernateSagaPersister()
            //       .UseNHibernateSubscriptionPersister()
            //       .UseNHibernateTimeoutPersister()
            //       .UseNHibernateGatewayPersister();

            Configure.With()
                     .DefaultBuilder()
                     .UseNHibernateSagaPersister()
                     .UseInMemoryGatewayPersister()
                     .UseInMemoryTimeoutPersister()
                     
                     ;
            Configure.Transactions.Disable();
            

        }
        
    }

}