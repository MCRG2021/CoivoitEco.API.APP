using CovoitEco.Core.Application.Services.Annonce.Commands;
using CovoitEco.Core.Application.Services.Annonce.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoivoitEco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonceController : ApiController
    {
        private readonly ILogger<AnnonceController> _logger = null;
        public AnnonceController(ILogger<AnnonceController> logger)
        {
            _logger = logger;
        }

        //[DisableCors]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AnnonceProfileVm>> GetAllAnnonceProfile(int id)
        {
            try
            {
                _logger.LogInformation("GetAllAnnonceProfile");
                var test = await Mediator.Send(new GetAllAnnonceProfileQuery() {UTL_Id = id});
                return test;
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAllAnnonceProfile fail");
                throw;
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetAnnonceReservation(int id)
        {
            try
            {
                _logger.LogInformation("GetAnnonceReservation");
                return await Mediator.Send(new GetAnnonceReservationQuery() {ANN_Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAnnonceReservation fail");
                throw;
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateAnnonce(CreateAnnonceCommand command)
        {
            try
            {
                _logger.LogInformation("CreateAnnonce");
                return await Mediator.Send(command); ;
            }
            catch (Exception e)
            {
                _logger.LogError("Request CreateAnnonce fail");
                throw;
            }
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AnnonceProfileVm>> GetAnnonceRecherche(DateTime departureDate, string departureCity, string arrivalCity)
        {
            try
            {
                _logger.LogInformation("GetAnnonceRecherche");
                return await Mediator.Send(new GetAnnonceRechercheQuery(){ANNREC_DateDepart = departureDate,ANNREC_VilleDepart =departureCity,ANNREC_VilleArrive = arrivalCity});
            }
            catch (Exception e)
            {
                _logger.LogError("Request GetAnnonceRecherche fail");
                throw;
            }
        }
    }
}
