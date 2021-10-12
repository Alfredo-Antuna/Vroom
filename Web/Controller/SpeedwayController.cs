using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    [ApiController]
    [Route("api")]
    public class SpeedwayController : ControllerBase
    {
        private ISpeedwayRepository _repository;
        public SpeedwayController(ISpeedwayRepository repo)
        {
            _repository = repo;
        }
        [HttpPost("cars")]
        public async Task<IActionResult> AddCar(CarDto carDto)
        {
            //Car car = new Car(carDto);
            await _repository.AddCarAsync(carDto);
            await _repository.SaveAsync();
            //return CreatedAtAction("GetCar", new { car.Id }, car);\
            return Ok();

        }
        [HttpGet("{car}")]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var car = await _repository.GetCarAsync(id);
            return Ok(car);
        }

        [HttpGet("cars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _repository.GetAllCarsAsync();
            return Ok(cars);
        }


    }
}