using System;
using Xunit;
using FluentAssertions;
using Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class RaceDtoTest
    {
        [Fact]
        public void ShouldCreate()
        {
            var driverId = new Guid();
            var winner = new Guid();
            var raceDate = new DateTime(1999, 1, 1);
            var dOB = new DateTime(1999, 1, 1);
            Driver TestDriver = new Driver() { Id = driverId, Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = dOB, Wins = 1, Losses = 20 };
            List<Driver> Participants = new() { TestDriver };
            RaceDto TestRace = new RaceDto() { Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate, Winner = winner };
            Race myRace = new Race(TestRace, Participants);
            myRace.Name.Should().Be("Tow");
            myRace.Category.Should().Be(CategoryEnum.Drag);
            myRace.Date.Should().Be(raceDate);
            myRace.Winner.Should().Be(winner);
            myRace.Participants.Should().HaveCount(1);
        }
        [Fact]
        public void ShouldNotCreateFutureRace()
        {
            var driverId = new Guid();
            var winner = new Guid();
            var raceDate = new DateTime(2022, 1, 1);
            var dOB = new DateTime(1999, 1, 1);

            Driver TestDriver = new Driver() { Id = driverId, Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = dOB, Wins = 1, Losses = 20 };
            List<Driver> Participants = new() { TestDriver };
            RaceDto TestRace = new RaceDto() { Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate, Winner = winner };
            var context = new ValidationContext(TestRace);
            Action act = () => Validator.ValidateObject(TestRace, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains(""));
        }
        [Fact]
        public void ShouldNotCreateNegativeBestTime()
        {
            var driverId = new Guid();
            var winner = new Guid();
            var raceDate = new DateTime(1999, 1, 1);
            var dOB = new DateTime(1999, 1, 1);

            Driver TestDriver = new Driver() { Id = driverId, Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = dOB, Wins = 1, Losses = 20 };
            List<Driver> Participants = new() { TestDriver };
            RaceDto TestRace = new RaceDto() { Name = "Tow", Category = CategoryEnum.Drag, BestTime = -1, Date = raceDate, Winner = winner };
            var context = new ValidationContext(TestRace);
            Action act = () => Validator.ValidateObject(TestRace, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains(""));
        }
    }
}