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
        public void ShouldNotCreateFutureRace()
        {
            var winner = new Guid();
            var raceDate = new DateTime(2022, 1, 1);
            RaceDto TestRace = new RaceDto() { Name = "Tow", Category = CategoryEnum.Drag, Date = raceDate, Winner = winner };
            var context = new ValidationContext(TestRace);
            Action act = () => Validator.ValidateObject(TestRace, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains(""));
        }
        [Fact]
        public void ShouldNotCreateNegativeBestTime()
        {
            var winner = new Guid();
            var raceDate = new DateTime(1999, 1, 1);
            RaceDto TestRace = new RaceDto() { Name = "Tow", Category = CategoryEnum.Drag, BestTime = -1, Date = raceDate, Winner = winner };
            var context = new ValidationContext(TestRace);
            Action act = () => Validator.ValidateObject(TestRace, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains(""));
        }
    }
}