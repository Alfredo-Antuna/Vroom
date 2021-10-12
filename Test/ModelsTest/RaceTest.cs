using System;
using Xunit;
using FluentAssertions;
using Web;

namespace Test
{
    public class RaceTest
    {
        [Fact]
        public void ShouldCreate()
        {
            var test = new Guid();
            var winner = new Guid();
            var RaceDate = new DateTime(1999, 1, 1);
            Race TestRace = new Race() { Id = test, Name = "Tow", Category = CategoryEnum.Drag, BestTime = 1, Date = RaceDate, Winner = winner };

            TestRace.BestTime.Should().Be(1);
            TestRace.Id.Should().Be(test);
            TestRace.Name.Should().Be("Tow");
            TestRace.Category.Should().Be(CategoryEnum.Drag);
            TestRace.Date.Should().Be(RaceDate);
            TestRace.Winner.Should().Be(winner);
        }
    }
}