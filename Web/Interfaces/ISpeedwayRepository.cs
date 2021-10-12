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
        //add Race
        //get Cars
        //get Drivers
        //get Races


    }
}
