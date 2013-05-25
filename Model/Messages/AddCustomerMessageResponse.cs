using NServiceBus;

namespace Model.Messages
{
   public class AddCustomerMessageResponse :IMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
