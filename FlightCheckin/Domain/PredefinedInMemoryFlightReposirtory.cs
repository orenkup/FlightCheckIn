using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckin
{
    /// <summary>
    /// This is an InMemoryFlightRepository with predifined dta used for this assignment. 
    /// </summary>
    public class PredefinedInMemoryFlightRepository :InMemoryFlightRepository
    {        
        public PredefinedInMemoryFlightRepository() : base()         
        {

            base.Save(new Flight { Aircraft = new Aircraft { Id = 1, Name = "Airbus", NumberOfSeats = 50, TotalBaggageWeight = 2950 }, Id = 1, MaximumBaggagesPerPassenger = 2, MaximumBaggageWeightPerPassenger = 60 , OccupiedSeats = ConfigureOccupiedSeats (45, 60)});

            base.Save(new Flight { Aircraft = new Aircraft { Id = 2, Name = "Boing", NumberOfSeats = 100, TotalBaggageWeight = 7800 }, Id = 2, MaximumBaggagesPerPassenger = 3, MaximumBaggageWeightPerPassenger = 100 , OccupiedSeats = ConfigureOccupiedSeats(75, 100)});

        }

        private List<SeatAssignment> ConfigureOccupiedSeats(int numOfPassangers, double baggageWeight)
        {
            var seats = new List<SeatAssignment>();
            for (int i = 0; i < numOfPassangers; i++)
            {
                seats.Add(new SeatAssignment { BaggageWeight = baggageWeight, SeatNumber = i + 1, PassangerId = i + 1000 });
            }
            return seats;
        }
    }
}
