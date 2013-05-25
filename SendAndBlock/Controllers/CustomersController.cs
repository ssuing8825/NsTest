using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Model.Messages;
using NServiceBus;

namespace SendAndBlock.Controllers
{
    public class CustomersController : ApiController
    {
        public CustomersController()
        {

        }

        /// <summary>
        /// Gets or sets an instance of the Bus.
        /// </summary>
        /// <value>An instance of the Bus.</value>
        public IBus Bus { get; set; }

        public HttpResponseMessage Post(Customer customer)
        {
            var message = new AddCustomerMessage { Name = customer.Name };
            //Fully Azync
            Bus.Send("Receiver", message);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}