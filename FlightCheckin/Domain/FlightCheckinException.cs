using System;

namespace FlightCheckin
{
    /// <summary>
    /// An exception for the FlightCheckin process
    /// </summary>
    public class FlightCheckinException : Exception
    {
        public FlightCheckinException(string message) : base(message)
        {
        }
    }
}