using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace Web
{
    public class SpeedwayRepository : ISpeedwayRepository
    {
        private Database _db;
        public SpeedwayRepository(Database db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _db.Cars.ToListAsync();
        }

        public async Task AddCarAsync(CarDto carDto)
        {
            Car car = new Car(carDto);
            await _db.AddAsync(car);

        }
        public async Task <Car> GetCar (Guid carId)
        {
          var car = await _db.Cars.Where(car => car.Id == carId).FirstOrDefaultAsync();
            return car;

        }
        public async Task AddDriverAsync(DriverDto driverDto)
        {
            Driver driver = new Driver(driverDto);
            await _db.AddAsync(driver);

        }
        public async Task AddRaceAsync(RaceDto raceDto)
        {
            List<Driver> participants = new ();
            Driver checkDriver;

            foreach (Guid part in raceDto.ParticipantsIds)
            {
                checkDriver = await _db.Drivers.Where(driver => driver.Id == part).FirstOrDefaultAsync();
                if (checkDriver != null) { participants.Add(checkDriver); }
                else { throw new Exception(); }
            }

            Race race = new Race(raceDto, participants);
            await _db.AddAsync(race);

        }
        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _db.Cars.ToListAsync();
        }
        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _db.Drivers.ToListAsync();
        }
        public async Task<IEnumerable<Race>> GetAllRacesAsync()
        {
            return await _db.Races.ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}