using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            Car car = new(carDto);
            await _db.AddAsync(car);

        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}