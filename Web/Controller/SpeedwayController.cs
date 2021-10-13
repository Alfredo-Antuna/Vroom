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
           // Car car = new Car(carDto);
            await _repository.AddCarAsync(carDto);
            await _repository.SaveAsync();
            return Ok();
           // return CreatedAtAction("GetCar", new { car.Id }, car);
        }
        [HttpGet("{car}")]
        public async Task<IActionResult> GetCar(Guid car)
        {
            var car2 = await _repository.GetCar(car);
            return Ok(car2);
        }

        [HttpGet("cars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _repository.GetAllCarsAsync();
            return Ok(cars);
        }


    }
}