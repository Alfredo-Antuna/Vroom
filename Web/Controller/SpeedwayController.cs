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
            Car car = new Car(carDto);
            await _repository.AddCarAsync(car);
            await _repository.SaveAsync();
            //return Ok();
            return CreatedAtAction("GetCar", new { CarId = car.Id }, car);
        }
        [HttpGet("cars/{CarId}")]
        public async Task<IActionResult> GetCar(Guid CarId)
        {
            var car = await _repository.GetCar(CarId);
            if (car is null) return NotFound();
            return Ok(car);
        }

        [HttpGet("cars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _repository.GetAllCarsAsync();
            return Ok(cars);
        }
        [HttpPost("drivers")]
        public async Task<IActionResult> AddDriver(DriverDto driverDto)
        {
            Driver driver = new Driver(driverDto);
            await _repository.AddDriverAsync(driver);
            await _repository.SaveAsync();
            //return Ok();
            return CreatedAtAction("GetDriver", new { DriverId = driver.Id }, driver);
        }

        [HttpGet("drivers/{DriverId}")]
        public async Task<IActionResult> GetDriver(Guid DriverId)
        {
            var driver = await _repository.GetDriver(DriverId);
            if (driver is null) return NotFound();
            return Ok(driver);
        }
        [HttpGet("drivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _repository.GetAllDriversAsync();
            return Ok(drivers);
        }
    }
}