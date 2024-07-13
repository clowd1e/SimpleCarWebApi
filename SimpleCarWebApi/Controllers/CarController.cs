using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCarWebApi.Dto;
using SimpleCarWebApi.Models;
using SimpleCarWebApi.Repository;

namespace SimpleCarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCars()
        {
            var cars = _mapper.Map<IEnumerable<CarDto>>(_carRepository.GetAllCars());

            if (cars is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type = typeof(CarDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCar(int carId)
        {
            var car = _mapper.Map<CarDto>(_carRepository.GetCar(carId));

            if (car is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(car);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCar([FromQuery] int carBodyTypeId, [FromQuery] int carBrandId, [FromBody] CarDto carDto)
        {
            if (carDto is null)
                return BadRequest();

            var car = _mapper.Map<CarDto>(
                _carRepository.GetAllCars()
                .FirstOrDefault(c => c.Model.Trim().ToLower() == carDto.Model.TrimEnd().ToLower()));

            if (car is not null)
            {
                ModelState.AddModelError("", "Car already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carMap = _mapper.Map<Car>(carDto);

            if (!_carRepository.AddCar(carBodyTypeId, carBrandId, carMap))
            {
                ModelState.AddModelError("", $"Something went wrong saving the record \"{carMap.Model}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully created record with name \"{carMap.Model}\"");
        }

        [HttpPut("{carId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCar(int carId, [FromBody] CarDto updatedCar)
        {
            if (updatedCar is null)
                return BadRequest(ModelState);

            if (carId != updatedCar.Id)
                return BadRequest(ModelState);

            var car = _carRepository.GetCar(carId);

            if (car is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carMap = _mapper.Map<Car>(updatedCar);

            if (!_carRepository.UpdateCar(carMap))
            {
                ModelState.AddModelError("", $"Something went wrong updating the record with id \"{carId}\"");
                return StatusCode(500, ModelState);
            }
            
            return Ok($"Successfully updated record with id \"{carId}\"");
        }

        [HttpDelete("{carId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCar(int carId)
        {
            var car = _carRepository.GetCar(carId);

            if (car is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.DeleteCar(carId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the record with id \"{carId}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully deleted record with id \"{carId}\"");
        }
    }
}
