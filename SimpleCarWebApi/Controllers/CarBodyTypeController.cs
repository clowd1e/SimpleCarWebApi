using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCarWebApi.Dto;
using SimpleCarWebApi.Models;
using SimpleCarWebApi.Repository;

namespace SimpleCarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBodyTypeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarBodyTypeController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarBodyTypeDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarBodyTypes()
        {
            var carBodyTypes = _mapper.Map<IEnumerable<CarBodyTypeDto>>(_carRepository.GetAllCarBodyTypes());

            if (carBodyTypes is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carBodyTypes);
        }

        [HttpGet("{carBodyTypeId}")]
        [ProducesResponseType(200, Type = typeof(CarBodyTypeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarBodyType(int carBodyTypeId)
        {
            var carBodyType = _mapper.Map<CarBodyTypeDto>(_carRepository.GetCarBodyType(carBodyTypeId));

            if (carBodyType is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carBodyType);
        }

        [HttpGet("{carBodyTypeId}/cars")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarsByBodyType(int carBodyTypeId)
        {
            var cars = _mapper.Map<IEnumerable<CarDto>>(_carRepository.GetCarsByBodyType(carBodyTypeId));

            if (cars is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCarBodyType([FromBody] CarBodyTypeDto carBodyTypeDto)
        {
            if (carBodyTypeDto is null)
                return BadRequest();

            var carBodyType = _mapper.Map<CarBodyTypeDto>(
                _carRepository.GetAllCarBodyTypes()
                .FirstOrDefault(cbt => cbt.Name.Trim().ToLower() == carBodyTypeDto.Name.TrimEnd().ToLower()));

            if (carBodyType is not null)
            {
                ModelState.AddModelError("", "Car body type already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_carRepository.AddCarBodyType(_mapper.Map<CarBodyType>(carBodyTypeDto)))
            {
                ModelState.AddModelError("", $"Something went wrong saving the record \"{carBodyTypeDto.Name}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully created record with name \"{carBodyTypeDto.Name}\"");
        }

        [HttpDelete("{carBodyTypeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCarBodyType(int carBodyTypeId)
        {
            var carBodyType = _carRepository.GetCarBodyType(carBodyTypeId);

            if (carBodyType is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.DeleteCarBodyType(carBodyTypeId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the record with id \"{carBodyTypeId}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully deleted record with id \"{carBodyTypeId}\"");
        }
    }
}
