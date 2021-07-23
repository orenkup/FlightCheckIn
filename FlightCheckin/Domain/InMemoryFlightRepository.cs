using System.Linq;
using System.Collections.Generic;

namespace FlightCheckin
{
    /// <summary>
    /// An in memory representation of the flight repository 
    /// </summary>
    public class InMemoryFlightRepository : IFlightRepository
    {
        #region fields

        private List<Flight> _db;

        #endregion

        #region ctor

        public InMemoryFlightRepository()
        {
            _db = new List<Flight>();
        }

        #endregion

        #region methods

        /// <summary>
        /// Gets the flight from the in memory database according to the given flightId.
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Flight GetByID(int flightId) => _db.FirstOrDefault(f => f.Id == flightId);

        /// <summary>
        /// Saves the flight into the in mempry database.
        /// </summary>
        /// <param name="flight"></param>
        public void Save(Flight flight)
        {
            var existingFlight = _db.FirstOrDefault(f => f.Id == flight.Id);
            _db.Remove(existingFlight);
            _db.Add(flight);
        }

        #endregion
    }
}