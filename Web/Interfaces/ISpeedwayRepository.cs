using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
    public interface ISpeedwayRepository
    {
        Task SaveAsync();
        //add Car
        Task AddCarAsync(CarDto carDto);
        //add Driver
        Task AddDriverAsync(DriverDto DriverDto);
        //add Race
        Task AddRaceAsync(RaceDto raceDto);
        //get Cars
        Task<IEnumerable<Car>> GetAllCarsAsync();
        //get Drivers
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        //get Races
        Task<IEnumerable<Race>> GetAllRacesAsync();
        //get one Car
        Task <Car> GetCar (Guid carId);
    }
}
