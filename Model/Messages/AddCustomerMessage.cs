using NServiceBus;

namespace Model.Messages
{
    public class AddCustomerMessage : IMessage
    {
        public string Name { get; set; }
    }
}
