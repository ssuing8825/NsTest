using NServiceBus;
using NHibernate.Cfg;

namespace CustomerAccountSystem
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                     .DefaultBuilder()
                     .RavenPersistence()
                     .UseTransport<NServiceBus.RabbitMQ>();

            Configure.Transactions.Disable();
        }
    }
}