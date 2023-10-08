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
            Assert.IsNotInstanceOfType(result, typeof(Ok<WeatherForecast[]>));
            Assert.IsInstanceOfType(result, typeof(Ok<IEnumerable<WeatherForecast>>));
        }      
    }
    // </snippet_1>
}
