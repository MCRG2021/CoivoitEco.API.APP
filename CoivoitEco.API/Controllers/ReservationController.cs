using CovoitEco.Core.Application.Models;
using CovoitEco.Core.Application.Services.Reservation.Commands;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using CovoitEco.Core.Application.Services.VehiculeProfile.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ApiController
    {
        private readonly ILogger<ReservationController> _logger = null;
        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReservationProfileVm>> GetAllReservationProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetAllReservationProfile");
                return await Mediator.Send(new GetAllReservationProfileQuery() {ANN_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllReservationProfile fail");
                throw;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateReservation(CreateReservationCommand command)
        {
            try
            {
                _logger.LogInformation("CreateReservation");
                return await Mediator.Send(command); 
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateReservation fail");
                throw;
            }
        }
    }
}
