using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckin
{
    public class FlightCheckinInput
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int NumberOfBags { get; set; }
        public double TotalBaggageWeight { get; set; }
    }
}
