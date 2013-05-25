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
    public class CustomersSyncController : ApiController
    {
        /// <summary>
        /// Gets or sets an instance of the Bus.
        /// </summary>
        /// <value>An instance of the Bus.</value>
        public IBus Bus { get; set; }

        // POST api/values
        public async Task<HttpResponseMessage> Post(Customer customer)
        {
            var message = new AddCustomerMessage { Name = customer.Name };
            
            //SendAndBlock
            var t = await Bus.Send("Receiver", message).Register<AddCustomerMessageResponse>(c => (AddCustomerMessageResponse)c.Messages[0]);

            return Request.CreateResponse(HttpStatusCode.Created, new Customer {Id = t.Id });



        }
    }
}