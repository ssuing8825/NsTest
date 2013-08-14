using Model.Model;
using NServiceBus;

namespace Model.Events
{
   public interface ICustomerAddedEvent : ICustomerAddedEventBase
    {
       int PortfolioId { get; set; }
    }
   public interface ICustomerAddedEventBase : IEvent
   {
       Customer Customer { get; set; }
   }
}
