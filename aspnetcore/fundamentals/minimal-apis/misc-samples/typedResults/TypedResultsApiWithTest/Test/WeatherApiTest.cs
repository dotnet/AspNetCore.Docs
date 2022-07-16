using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Tests
{
    [TestClass()]
    public class WeatherApiTests
    {
        [TestMethod()]
        public void MapWeatherApiTest()
        {
            var result = WeatherApi.GetAllWeathers();
            // assert that the result is a typed result of type WeatherForecast[]
            Assert.IsInstanceOfType(result, typeof(Ok<WeatherForecast[]>));
        }
      
    }

}
