using FlightCheckin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightCheckinTests
{
    [TestClass]
    public class FlightCheckinServiceTest
    {
        [TestMethod]
        public void FlightCheckinService_CheckinSuccess_ReturnOperationResultSuccess()
        {
            var flightCheckinService = new FlightCheckinService(new PredefinedInMemoryFlightRepository());
            var res = flightCheckinService.CheckIn(1, 1, 2, 22);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void FlightCheckinService_FlightIdNotExist_ThrowsException_ReturnOperationResultFailure()
        {
            var flightCheckinService = new FlightCheckinService(new InMemoryFlightRepository ());
            var res = flightCheckinService.CheckIn(1, 1, 2, 22);
            Assert.IsFalse(res.IsSuccess);
			Assert.AreEqual("flight with id 1 does not exist.", res.ErrorMessage);			
        }

        [TestMethod]
        public void FlightCheckinService_NumberOfBagsExceedPassengerLimit_ReturnOperationResultFailure()
        {
            var flightCheckinService = new FlightCheckinService(new PredefinedInMemoryFlightRepository());
            var res = flightCheckinService.CheckIn(1, 1, 20, 22);
            Assert.IsFalse(res.IsSuccess);
            Assert.IsNotNull(res.ErrorMessage);
        }
    }
}

