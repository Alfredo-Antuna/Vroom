using System;
using Xunit;
using FluentAssertions;
using Web;

namespace Test
{
    public class CarTest
    {
        [Fact]
        public void ShouldCreate()
        {
            var test = new Guid();
            Car TestCar = new Car() { Id = test, Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };
            TestCar.Id.Should().Be(test);
            TestCar.Model.Should().Be(ModelEnum.Nissan);
            TestCar.Nickname.Should().Be("Tow-mater");
            TestCar.Year.Should().Be(2020);
            TestCar.IsAvailable.Should().Be(true);
            TestCar.TopSpeed.Should().Be(220);
            TestCar.Type.Should().Be(TypeEnum.Truck);
        }
    }
}