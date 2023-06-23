using System.Net;
using House.API.Data;
using House.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace House.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository _repository;
        private readonly ILogger<HouseController> _logger;


        public HouseController(IHouseRepository repository, ILogger<HouseController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.House>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.House>>> GetHouses()
        {
            var Houses = await _repository.GetHouses();
            return Ok(Houses);
        }

        [HttpGet("{id:length(24)}", Name = "GetHouses")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.House), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.House>> GetHouseById(string id)
        {
            var house = await _repository.GetHouse(id);

            if (house == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(house);
        }

        [Route("[action]/{category}", Name = "GetHouseByModel")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.House>), (int)HttpStatusCode.OK)]
        

        [Route("[action]/{name}", Name = "GetHouseByCity")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entities.House>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.House>>> GetHouseByBCity(string city)
        {
            var houses = await _repository.GetHouseByCity(city);
            if (houses == null)
            {
                _logger.LogError($"Products with name: {city} not found.");
                return NotFound();
            }

            return Ok(houses);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.House), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.House>> CreateHouse([FromBody] Entities.House house)
        {
            await _repository.CreateHouse(house);

            return CreatedAtRoute("GetHouse", new { id = house.Id }, house);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.House), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateHouse([FromBody] Entities.House toUpdateHouse)
        {
            var house = await _repository.UpdateHouse(toUpdateHouse);
            if (house == true)
            {
                return Ok();
            }

            return Forbid();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Entities.House), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteHouseById(string id)
        {
            var house = await _repository.DeleteHouse(id);
            if (house == true)
            {
                return Ok();
            }

            return Forbid();
        }
    }
}