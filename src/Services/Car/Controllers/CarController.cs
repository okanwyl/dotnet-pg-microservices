using System.Net;
using Car.API.Data;
using Car.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly ILogger<CarController> _logger;


        public CarController(ICarRepository repository, ILogger<CarController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Car>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Car>>> GetCars()
        {
            var cars = await _repository.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id:length(24)}", Name = "GetCars")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Car), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Car>> GetCarById(string id)
        {
            var car = await _repository.GetCar(id);

            if (car == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(car);
        }

        [Route("[action]/{category}", Name = "GetCarByModel")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Car>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Car>>> GetCarByModel(string model)
        {
            var cars = await _repository.GetCarByModel(model);
            return Ok(cars);
        }

        [Route("[action]/{name}", Name = "GetCarByBrand")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entities.Car>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Car>>> GetCarByBrand(string brand)
        {
            var cars = await _repository.GetCarByBrand(brand);
            if (cars == null)
            {
                _logger.LogError($"Products with name: {brand} not found.");
                return NotFound();
            }

            return Ok(cars);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Car), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Car>> CreateCar([FromBody] Entities.Car car)
        {
            await _repository.CreateCar(car);

            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Car), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCar([FromBody] Entities.Car toUpdateCar)
        {
            var car = await _repository.UpdateCar(toUpdateCar);
            if (car == true)
            {
                return Ok();
            }

            return Forbid();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Entities.Car), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCarById(string id)
        {
            var car = await _repository.DeleteCar(id);
            if (car == true)
            {
                return Ok();
            }

            return Forbid();
        }
    }
}