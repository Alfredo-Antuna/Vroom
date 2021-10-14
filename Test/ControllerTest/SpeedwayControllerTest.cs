using System;
using Xunit;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace test
{
  public class SpeedwayControllerTest
  {
    private SpeedwayController _controller;
    private Mock<ISpeedwayRepository> _mockRepository;
    private DefaultHttpContext _httpContext;
    
    public SpeedwayControllerTest()
    {
      _mockRepository = new Mock<ISpeedwayRepository>();
      _httpContext = new DefaultHttpContext();
      _controller = new SpeedwayController(_mockRepository.Object)
      { ControllerContext = new ControllerContext() { HttpContext = _httpContext } };
    }
    [Fact]
    public async Task ShouldAddCar()
    {
      CarDto TestCarDto = new CarDto() { Model = ModelEnum.Nissan, Nickname = "Tow-mater", Year = 2020, IsAvailable = true, TopSpeed = 220, Type = TypeEnum.Truck };  
      var result = await _controller.AddCar(TestCarDto);
      var createdActionResult = result as CreatedAtActionResult;
      createdActionResult.StatusCode.Should().Be(201);
      createdActionResult.ActionName.Should().Be("GetCar");
      createdActionResult.RouteValues["Id"].Should().NotBeNull();
    }
    
    }
}