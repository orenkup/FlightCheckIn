using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckin
{
    /// <summary>
    /// A contract for the flight checkin repository
    /// </summary>
    public interface IFlightRepository
    {
        /// <summary>
        /// Gets the flight by the flight id from the database.
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        Flight GetByID(int flightId);

        /// <summary>
        /// Saves the flight to the database.
        /// </summary>
        /// <param name="flight"></param>
        void Save(Flight flight);
    }
}
