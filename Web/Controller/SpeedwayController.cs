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

        [HttpPost("races")]
        public async Task<IActionResult> AddRace(RaceDto raceDto)
        {
            List<Guid> DriverList = raceDto.ParticipantsIds;
            var drivers = await _repository.GetDriversAsync(DriverList);
            Race race = new Race(raceDto, drivers.ToList());
            await _repository.AddRaceAsync(race);
            await _repository.SaveAsync();
            return CreatedAtAction("GetRace", new { raceId = race.Id }, race);
        }

        [HttpGet("races/{raceId}")]
        public async Task<IActionResult> GetRace(Guid RaceId)
        {
            var race = await _repository.GetRace(RaceId);
            if (race is null) return NotFound();
            return Ok(race);
        }
        [HttpGet("races")]
        public async Task<IActionResult> GetAllRaces()
        {
            var races = await _repository.GetAllRacesAsync();
            return Ok(races);
        }
    }
}