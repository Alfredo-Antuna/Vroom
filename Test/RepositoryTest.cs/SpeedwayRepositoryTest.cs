using System;
using Xunit;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web;
using System.Threading.Tasks;

namespace test.Repositories
{
    public class SpeedwayRepositoryTest
    {
        private Database _db;
        private ISpeedwayRepository _repo;

        public SpeedwayRepositoryTest()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
            _db = new Database(options);
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _repo = new SpeedwayRepository(_db);
        }

        [Fact]
        public async Task ShouldSaveCarToDatabase()
        {
            CarDto testCarDto = new CarDto() { Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };
            await _repo.AddCarAsync(testCarDto);
            await _repo.SaveAsync();
            _db.Cars.Count().Should().Be(1);
        }

    }
}
