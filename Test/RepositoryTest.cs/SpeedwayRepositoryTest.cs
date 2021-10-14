using System;
using Xunit;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            Car car = new Car(testCarDto);
            await _repo.AddCarAsync(car);
            await _repo.SaveAsync();
            _db.Cars.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldSaveDriverToDatabase()
        {
            var DOB = new DateTime(1999, 1, 1);
            DriverDto testDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = 1, Losses = 20 };
            Driver driver = new Driver(testDriverDto);
            await _repo.AddDriverAsync(driver);
            await _repo.SaveAsync();
            _db.Drivers.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldSaveRaceToDatabase()
        {
            var winner = new Guid();
            var raceDate = new DateTime(1999, 1, 1);
            var DOB = new DateTime(1999, 1, 1);
            DriverDto testDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = 1, Losses = 20 };
            Driver driver = new Driver(testDriverDto);
            await _repo.AddDriverAsync(driver);
            List<Driver> Participants = await _db.Drivers.ToListAsync();
            Race testRace =new Race() { Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate, Winner = winner };
            await _repo.AddRaceAsync(testRace);
            await _repo.SaveAsync();
            _db.Races.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldGetAllCars()
        {
            CarDto testCarDto = new CarDto() { Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };
            Car car = new Car(testCarDto);
            await _repo.AddCarAsync(car);
            CarDto testCarDto2 = new CarDto() { Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };
            Car car2 = new Car(testCarDto2);
            await _repo.AddCarAsync(car2);
            await _repo.SaveAsync();
            var todos = await _repo.GetAllCarsAsync();
            todos.Should().HaveCount(2);
        }
        [Fact]
        public async Task ShouldGetAllDrivers()
        {
            var DOB = new DateTime(1999, 1, 1);
            DriverDto testDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = 1, Losses = 20 };
            Driver driver = new Driver(testDriverDto);
            await _repo.AddDriverAsync(driver);
            var DOB2 = new DateTime(1999, 1, 1);
            DriverDto testDriverDto2 = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB2, Wins = 1, Losses = 20 };
            Driver driver2 = new Driver(testDriverDto2);
            await _repo.AddDriverAsync(driver2);
            await _repo.SaveAsync();
            var todos = await _repo.GetAllDriversAsync();
            todos.Should().HaveCount(2);
        }
        [Fact]
        public async Task ShouldGetAllRaces()
        {
            var winner = new Guid();
            var raceDate = new DateTime(1999, 1, 1);
            List<Guid> ParticipantIds = await _db.Drivers.Select(driver => driver.Id).ToListAsync();
           Race race = new Race(){ Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate, Winner = winner};
            await _repo.AddRaceAsync(race);
            var winner2 = new Guid();
            var raceDate2 = new DateTime(1999, 1, 1);
            List<Guid> ParticipantIds2 = await _db.Drivers.Select(driver => driver.Id).ToListAsync();
            Race race2 = new Race(){ Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate2, Winner = winner2 };
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var todos = await _repo.GetAllRacesAsync();
            todos.Should().HaveCount(2);
        }

    }
}
