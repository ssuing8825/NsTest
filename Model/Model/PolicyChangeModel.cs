using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    class PolicyChangeCommand
    {
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }

        List<Vehicle> VehiclesAdded { get; set; }
        List<Vehicle> VehiclesDeleted { get; set; }
        List<Vehicle> VehiclesUpdated { get; set; }

        List<Coverage> CoveragesAdded { get; set; }
        List<Coverage> CoveragesDeleted { get; set; }
        List<Coverage> CoveragesUpdated { get; set; }

        DVA DVA { get; set; }
    }

    public class Vehicle { }

    public class DVA { }
    public class Coverage { }

}
