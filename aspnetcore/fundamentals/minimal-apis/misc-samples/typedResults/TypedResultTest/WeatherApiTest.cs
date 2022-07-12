using Microsoft.AspNetCore.Http.HttpResults;

namespace Tests
{
    [TestClass()]
    public class WeatherApiTests
    {
        [TestMethod()]
        public void MapWeatherApiTest()
        {
            //act
            var result = WeatherApi.GetAllWeathers();
            Console.WriteLine("hi");

            Assert.IsInstanceOfType(result, typeof(Ok<WeatherForecast[]>));
        }
      
    }

}