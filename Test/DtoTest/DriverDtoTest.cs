using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Web;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class DriverDtoTest
    {
        [Fact]
        public void ShouldCreate()
        {
            var DOB = new DateTime(1999, 1, 1);
            DriverDto TestDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = 1, Losses = 20 };
            TestDriverDto.Age.Should().Be(19);
            TestDriverDto.FirstName.Should().Be("Tow");
            TestDriverDto.LastName.Should().Be("Mater");
            TestDriverDto.DateOfBirth.Should().Be(DOB);
            TestDriverDto.Nickname.Should().Be("Tow-mater");
            TestDriverDto.Wins.Should().Be(1);
            TestDriverDto.Losses.Should().Be(20);
        }
        [Fact]
        public void ShouldNotCreateNegativeWins()
        {
            var DOB = new DateTime(1999, 1, 1);
            DriverDto TestDriverDto = new DriverDto() { Age = 19, FirstName = "Tow", LastName = "Mater", Nickname = "Tow-mater", DateOfBirth = DOB, Wins = -1, Losses = 20 };
            var context = new ValidationContext(TestDriverDto);
            Action act = () => Validator.ValidateObject(TestDriverDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains(""));
        }
    }
}