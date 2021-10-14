using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
    public interface ISpeedwayRepository
    {
        Task SaveAsync();
        //add Car
        Task AddCarAsync(Car car);
        //add Driver
        Task AddDriverAsync(Driver driver);
        //add Race
        Task AddRaceAsync(Race race);
        //get Cars
        Task<IEnumerable<Car>> GetAllCarsAsync();
        //get Drivers
        Task<IEnumerable<Driver>> GetDriversAsync(List <Guid> drivers);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        //get Races
        Task<IEnumerable<Race>> GetAllRacesAsync();
        //get one Car
        Task<Car> GetCar(Guid carId);
        Task<Driver> GetDriver(Guid DriverId);
        Task<Race> GetRace(Guid RaceId);
    }
}
