using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Tests
{
    // <snippet_1>
    [TestClass()]
    public class WeatherApiTests
    {
        [TestMethod()]
        public void MapWeatherApiTest()
        {
            var result = WeatherApi.GetAllWeathers();
            Assert.IsInstanceOfType(result, typeof(Ok<WeatherForecast[]>));
        }      
    }
    // </snippet_1>
}
