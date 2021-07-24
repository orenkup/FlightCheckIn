using FlightCheckin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlightCheckinTests
{
    [TestClass]
    public class FlightTest
    {
        [TestMethod]
        [ExpectedException(typeof(FlightCheckinException), $"3 is greater than allowd baggags per passenger 2")]
        public void FlightValidation_NumberOfBagNotValid_ThrowsException()
        {
            var flight = new Flight
            {
                MaximumBaggagesPerPassenger = 2
            };
            flight.Checkin(1, 3, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(FlightCheckinException), "20 is greater than allowd baggages weight 20")]
        public void FlightValidation_MaximumBaggageWeightExceededNotValid_ThrowsException()
        {
            var flight = new Flight
            {
                MaximumBaggagesPerPassenger = 2,
                MaximumBaggageWeightPerPassenger = 20
            };
            flight.Checkin(1, 3, 30);
        }


        [TestMethod]
        [ExpectedException(typeof(FlightCheckinException), $"All 2 seats in the flight are taken.")]
        public void FlightValidation_AircraftFullNotValid_ThrowsException()
        {
            var flight = new Flight
            {
                Aircraft = new Aircraft { Id = 1, NumberOfSeats = 2, TotalBaggageWeight = 200 },
                MaximumBaggagesPerPassenger = 2,
                MaximumBaggageWeightPerPassenger = 20,
                OccupiedSeats = new List<SeatAssignment> { new SeatAssignment { BaggageWeight = 10, PassangerId = 1, SeatNumber = 1 }, new SeatAssignment { BaggageWeight = 10, PassangerId = 2, SeatNumber = 2 } }
            };
            flight.Checkin(1, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(FlightCheckinException), $"Adding passenger baggages will exceed airfraft total weight limitation of 30.")]
        public void FlightValidation_AircraftWeightExceeded_ThrowsException()
        {
            var flight = new Flight
            {
                Aircraft = new Aircraft { Id = 1, NumberOfSeats = 3, TotalBaggageWeight = 30 },
                MaximumBaggagesPerPassenger = 2,
                MaximumBaggageWeightPerPassenger = 20,
                OccupiedSeats = new List<SeatAssignment> { new SeatAssignment { BaggageWeight = 10, PassangerId = 1, SeatNumber = 1 }, new SeatAssignment { BaggageWeight = 10, PassangerId = 2, SeatNumber = 2 } }
            };
            flight.Checkin(1, 1, 20);
        }

        [TestMethod]
        public void FlightValidationSucess_PassengerAddedToOccupiedSeats()
        {
            var flight = new Flight
            {
                Aircraft = new Aircraft { Id = 1, NumberOfSeats = 3, TotalBaggageWeight = 200 },
                MaximumBaggagesPerPassenger = 2,
                MaximumBaggageWeightPerPassenger = 20,
                OccupiedSeats = new List<SeatAssignment> { new SeatAssignment { BaggageWeight = 10, PassangerId = 1, SeatNumber = 1 }, new SeatAssignment { BaggageWeight = 10, PassangerId = 2, SeatNumber = 2 } }
            };
            flight.Checkin(1, 1, 20);
            Assert.AreEqual(3, flight.OccupiedSeats.Count);
        }

    }
}
