
using System;
using System.Collections.Generic;
using System.Linq;
using DevSecOps_net5._0;
using DevSecOps_net5._0.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DevSecOps_net5._0_Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly Mock<ILogger<WeatherForecastController>> _logger = new Mock<ILogger<WeatherForecastController>>();
        private readonly WeatherForecastController _weatherForecastController;

        public WeatherForecastControllerTests()
        {
            _weatherForecastController = new WeatherForecastController(_logger.Object);
        }

        [Fact]
        public void Constructor_All_Dependencies_Injected_Created_Successfully()
        {
            // Arrange & Act
            var controller = new WeatherForecastController(_logger.Object);
            
            // Assert
            Assert.NotNull(controller);
        }
        
        [Fact]
        public void Constructor_Logger_Null_Throws_Exception()
        {
            // Arrange & Act
            var exception = Assert.Throws<ArgumentNullException>(() => new WeatherForecastController(null));
            
            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void Get_Test()
        {
            // Arrange & Act
            var result = _weatherForecastController.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(5, result.Count());
        }
    }
}