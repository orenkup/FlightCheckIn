namespace FlightCheckin
{
    /// <summary>
    /// A contract for a flight checkin
    /// </summary>
    public interface IFlightCheckinService
    {
        OperationResult CheckIn(int flightId, int passengerId, int numberOfBags, double baggagesWeight);
    }
}