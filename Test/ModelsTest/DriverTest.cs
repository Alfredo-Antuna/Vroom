using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Web;
namespace Test
{
    public class DriverTest
    {


        [Fact]
        public void ShouldCreate()
        {
            var DOB = new DateTime(1999, 1, 1);
            DriverDto TestDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = 1, Losses = 20 };
            Driver TestDriver = new Driver(TestDriverDto);
            TestDriver.Age.Should().Be(19);
            TestDriver.FirstName.Should().Be("Tow");
            TestDriver.LastName.Should().Be("Mater");
            TestDriver.DateOfBirth.Should().Be(DOB);
            TestDriver.Nickname.Should().Be("Tow-mater");
            TestDriver.Wins.Should().Be(1);
            TestDriver.Losses.Should().Be(20);



        }
    }
}