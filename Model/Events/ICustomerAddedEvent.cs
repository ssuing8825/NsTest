﻿using Model.Model;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Events
{
    public interface ICustomerAddedEvent : IEvent
    {
        Customer Customer { get; set; }
    }
}
