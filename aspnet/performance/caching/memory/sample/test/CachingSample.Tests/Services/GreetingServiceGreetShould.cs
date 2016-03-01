using System;
using Xunit;
using CachingSample.Abstractions;
using CachingSample.Services;

namespace CachingSample.Tests.Services
{
    public class GreetingServiceGreetShould
    {
        private readonly TestTimeService _timeService;
        private readonly GreetingService _greetingService;

        public GreetingServiceGreetShould()
        {
            _timeService = new TestTimeService() { Now = DateTime.Now };
            _greetingService = new GreetingService(_timeService);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        public void SayGoodMorningBeforeNoon(int hour)
        {
            _timeService.Now = new DateTime(2016, 7, 1, hour, 0, 0);

            string greeting = _greetingService.Greet("tester");

            Assert.Equal("Good morning, tester!", greeting);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        public void SayGoodAfternoonBeforeFive(int hour)
        {
            _timeService.Now = new DateTime(2016, 7, 1, hour, 0, 0);

            string greeting = _greetingService.Greet("tester");

            Assert.Equal("Good afternoon, tester!", greeting);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        public void SayGoodEveningBeforeMidnight(int hour)
        {
            _timeService.Now = new DateTime(2016, 7, 1, hour, 0, 0);

            string greeting = _greetingService.Greet("tester");

            Assert.Equal("Good evening, tester!", greeting);
        }

        public class TestTimeService : ITimeService
        {
            public DateTime Now { get; set; }
        }
    }
}
