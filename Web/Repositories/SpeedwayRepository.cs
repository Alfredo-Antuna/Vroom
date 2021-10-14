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

        public async Task AddCarAsync(Car car)
        {
            await _db.AddAsync(car);
        }
        public async Task<Car> GetCar(Guid carId)
        {
            var car = await _db.Cars.Where(car => car.Id == carId).FirstOrDefaultAsync();
            return car;

        }
        public async Task AddDriverAsync(Driver driver)
        {
            await _db.AddAsync(driver);
        }
        public async Task<Driver> GetDriver(Guid driverId)
        {
            var driver = await _db.Drivers.Where(driver => driver.Id == driverId).FirstOrDefaultAsync();
            return driver;

        }
        public async Task<IEnumerable<Driver>> GetDriversAsync(List<Guid> driverIds)
        {
            List<Driver> drivers = new List<Driver>();
            Driver checkDriver= new Driver();
            foreach (Guid driverId in driverIds)
            {
                checkDriver = await _db.Drivers.Where(driver => driver.Id == driverId).FirstOrDefaultAsync();
                if (checkDriver != null) { drivers.Add(checkDriver); }

            }
            return drivers;
        }

        public async Task<Race> GetRace(Guid raceId)
        {
            var race = await _db.Races.Where(race => race.Id == raceId).FirstOrDefaultAsync();
            return race;

        }

        public async Task AddRaceAsync(Race race)
        {
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