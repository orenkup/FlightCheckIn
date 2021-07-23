using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckin
{
    /// <summary>
    /// This class is the Flight aggregate and it is resoponsible for the flight checkin process and it holds all the flight related data.
    /// </summary>
    public class Flight
    {
        #region Properties

        /// <summary>
        /// The id of the flight
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The <see cref="Aircraft>"/> that this flight has
        /// </summary>
        public Aircraft Aircraft { get; set; }

        /// <summary>
        /// The maximum baggage allowed per passanger for the flight
        /// </summary>
        public int MaximumBaggagesPerPassenger { get; set; }

        /// <summary>
        /// The maximoum baggage weight allowed per passanger for the flight
        /// </summary>
        public double MaximumBaggageWeightPerPassenger { get; set; }

        /// <summary>
        /// A list of the seats that were occupied by other passengers witgh their bags info
        /// </summary>
        public List<SeatAssignment> OccupiedSeats { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// The checkin process for the flight validate first the different invariants.
        /// In case the validations fail, it throws a<see cref="FlightCheckinException"/>.
        /// If all variants pass, it will add the passenger data to the flight.
        /// </summary>
        /// <param name="passengerId"></param>
        /// <param name="numberOfBags"></param>
        /// <param name="baggagesWeight"></param>
        public void Checkin(int passengerId, int numberOfBags, double baggagesWeight)
        {
            if (IsMaximumBaggageAmountExceeded(numberOfBags))
            {
                throw new FlightCheckinException($"{numberOfBags} is greater than allowd baggags per passenger {MaximumBaggagesPerPassenger}");
            }

            if (IsMaximumBaggageWeightExceeded(baggagesWeight))
            {
                throw new FlightCheckinException($"{baggagesWeight} is greater than allowd baggages weight {MaximumBaggageWeightPerPassenger}");
            }

            if (IsAircraftFull())
            {
                throw new FlightCheckinException($"All {Aircraft.NumberOfSeats} seats in the flight are taken.");
            }

            if (IsAircraftWeightExceeded(baggagesWeight))
            {
                throw new FlightCheckinException($"Adding passenger baggages will exceed airfraft total weight limitation of {Aircraft.TotalBaggageWeight}.");
            }

            OccupiedSeats.Add(new SeatAssignment
            {
                BaggageWeight = baggagesWeight,
                PassangerId = passengerId,
                SeatNumber = OccupiedSeats.Count + 1
            });
        }

        private bool IsMaximumBaggageAmountExceeded(int numberOfBags) => numberOfBags > MaximumBaggagesPerPassenger;
        private bool IsMaximumBaggageWeightExceeded(double baggagesWeight) => baggagesWeight > MaximumBaggageWeightPerPassenger;
        private bool IsAircraftFull() => OccupiedSeats.Count == Aircraft.NumberOfSeats;
        private bool IsAircraftWeightExceeded(double baggagesWeight) => OccupiedSeats.Sum(s => s.BaggageWeight) + baggagesWeight > Aircraft.TotalBaggageWeight;

        #endregion
    }
}
