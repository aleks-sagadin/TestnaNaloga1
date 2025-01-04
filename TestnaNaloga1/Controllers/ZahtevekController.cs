using Microsoft.AspNetCore.Mvc;
using TestnaNaloga.Application;
using TestnaNaloga.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestnaNaloga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtevekController : ControllerBase
    {
        private readonly IZahtevekService _zahtevekService;
        private readonly ILogger<ZahtevekController> logger;

        public ZahtevekController(IZahtevekService service, ILogger<ZahtevekController> logger)
        {
            _zahtevekService = service;
            this.logger = logger;
        }


        // GET: api/<ZahtevekController>
        [HttpGet]
        public ActionResult<List<Zahtevek>> Get()
        {
            var zahtevekFromServiceList = _zahtevekService.GetAllZahtevek();
            return Ok(zahtevekFromServiceList);
        }

        // GET api/<ZahtevekController>/5
        [HttpGet("{id}")]
        public ActionResult<Zahtevek> Get(int id)
        {
            try
            {
                var zahtevek = _zahtevekService.GetZahtevek(id);
                return Ok(zahtevek);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentNullException)
            {
                logger.LogError("[Get] Zahtevek with ID {} was not found.", id);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");

            }
        }
        // POST api/<ZahtevekController>
        [HttpPost]
        public ActionResult<Zahtevek> Post([FromBody] Zahtevek zahtevek)
        {
            try
            {
                var Zahtevek = _zahtevekService.CreateZahtevek(zahtevek);
                return Ok(zahtevek);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");

            }
        }


        // PUT api/<ZahtevekController>/5
        [HttpPut("{id}")]
        public ActionResult<Zahtevek> Put(int id, [FromBody] Zahtevek zahtevek)
        {
            try
            {
                var Zahtevek = _zahtevekService.UpdateZahtevek(id, zahtevek);
                return Ok(zahtevek);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentNullException)
            {
                // Log the exception (use your logger)
                logger.LogError("[Put] Zahtevek with ID {} was not found.", id);
                // Optionally, you can throw a custom exception or return a specific error response
                return NotFound($"Zahtevek with ID {id} was not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");

            }
        }

        // DELETE api/<ZahtevekController>/5
        [HttpDelete("{id}")]
        public ActionResult<Zahtevek> Delete(int id)
        {
            try
            {
                var zahtevek = _zahtevekService.DeleteZahtevek(id);
                return Ok(zahtevek);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentNullException)
            {
                // Log the exception (use your logger)
                logger.LogError("[Delete] Zahtevek with ID {} was not found.", id);
                // Optionally, you can throw a custom exception or return a specific error response
                return NotFound($"Zahtevek with ID {id} was not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");

            }
        }

    }
}
