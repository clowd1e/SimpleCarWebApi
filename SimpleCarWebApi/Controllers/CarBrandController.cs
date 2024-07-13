using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCarWebApi.Dto;
using SimpleCarWebApi.Models;
using SimpleCarWebApi.Repository;

namespace SimpleCarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarBrandController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarBrandDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarBrands()
        {
            var carBrands = _mapper.Map<IEnumerable<CarBrandDto>>(_carRepository.GetAllCarBrands());

            if (carBrands is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carBrands);
        }

        [HttpGet("{carBrandId}")]
        [ProducesResponseType(200, Type = typeof(CarBrandDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarBrand(int carBrandId)
        {
            var carBrand = _mapper.Map<CarBrandDto>(_carRepository.GetCarBrand(carBrandId));

            if (carBrand is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carBrand);
        }

        [HttpGet("{carBrandId}/cars")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCarsByBrand(int carBrandId)
        {
            var cars = _mapper.Map<CarBrandDto>(_carRepository.GetCarBrand(carBrandId));

            if (cars is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCarBrand([FromBody] CarBrandDto carBrandDto)
        {
            if (carBrandDto is null)
                return BadRequest();

            var carBrand = _mapper.Map<CarBrandDto>(
                _carRepository.GetAllCarBrands()
                .FirstOrDefault(cb => cb.Name.Trim().ToLower() == carBrandDto.Name.TrimEnd().ToLower()));

            if (carBrand is not null)
            {
                ModelState.AddModelError("", "Car brand already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.AddCarBrand(_mapper.Map<CarBrand>(carBrandDto)))
            {
                ModelState.AddModelError("", $"Something went wrong saving the record \"{carBrandDto.Name}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully created record with name \"{carBrandDto.Name}\"");
        }

        [HttpDelete("{carBrandId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCarBrand(int carBrandId)
        {
            var carBrand = _carRepository.GetCarBrand(carBrandId);

            if (carBrand is null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.DeleteCarBrand(carBrandId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the record with id \"{carBrandId}\"");
                return StatusCode(500, ModelState);
            }

            return Ok($"Successfully deleted record with id \"{carBrandId}\"");
        }
    }
}
