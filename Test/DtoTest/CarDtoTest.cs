using System;
using Xunit;
using FluentAssertions;
using Web;

namespace Test
{
    public class CarDtoTest
    {
        [Fact]
        public void ShouldCreate()
        {
            CarDto TestCarDto = new CarDto() { Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };
            TestCarDto.Model.Should().Be(ModelEnum.Nissan);
            TestCarDto.Nickname.Should().Be("Tow-mater");
            TestCarDto.Year.Should().Be(2020);
            TestCarDto.IsAvailable.Should().Be(true);
            TestCarDto.TopSpeed.Should().Be(220);
            TestCarDto.Type.Should().Be(TypeEnum.Truck);
        }
    }
}