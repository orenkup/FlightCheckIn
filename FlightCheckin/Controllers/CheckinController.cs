using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightCheckin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightCheckinController : ControllerBase
    {
        private IFlightCheckinService _flightCheckinService;

        public FlightCheckinController(IFlightCheckinService flightCheckinService)
        {
            _flightCheckinService = flightCheckinService;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] FlightCheckinInput input)
        {
            var result = _flightCheckinService.CheckIn(input.FlightId, input.PassengerId, input.NumberOfBags, input.TotalBaggageWeight);
            return StatusCode(result.IsSuccess? StatusCodes.Status201Created: StatusCodes.Status400BadRequest,result.ErrorMessage);
        }

    }
}
