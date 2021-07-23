using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightCheckin
{
    /// <summary>
    /// A Class that is responsible for a passenger checkin to a flight.
    /// </summary>
    public class FlightCheckinService : IFlightCheckinService
    {
        #region fields
        
        private IFlightRepository _flightRepository;

        #endregion

        #region ctor

        public FlightCheckinService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        #endregion

        #region methods

        /// <summary>
        /// Checkin for a passenger to a given flight.
        /// </summary>
        /// <param name="flightId">the flight to checkin to</param>
        /// <param name="passengerId">the passenger that checks in</param>
        /// <param name="numberOfBags">the number of bags of the passenger</param>
        /// <param name="baggagesWeight">the total weight of the baggages of the passenger</param>
        /// <returns>A <see cref="OperatgionResult"/> object indicating if the checkin suceeded or not and athe error message in case ther checkin failed.</returns>
        public OperationResult CheckIn(int flightId,int passengerId, int numberOfBags, double baggagesWeight)
        {
            var result = new OperationResult();
            try
            {
                var flight = _flightRepository.GetByID(flightId);
				if(flight!=null)
				{
					flight.Checkin(passengerId, numberOfBags, baggagesWeight);
					_flightRepository.Save(flight);
					result.IsSuccess = true;
				}
				else
				{					
					result.ErrorMessage = $(flight with id {flightId} does not exist.";
				}
            }
            catch (Exception ex)
            {                
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        #endregion
    }
}
