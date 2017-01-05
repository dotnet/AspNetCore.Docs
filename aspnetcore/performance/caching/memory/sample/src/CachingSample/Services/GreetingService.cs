using CachingSample.Abstractions;

namespace CachingSample.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly ITimeService _timeService;

        public GreetingService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string Greet(string recipient)
        {
            var time = _timeService.Now;
            int hour = time.Hour;

            if(time.Hour < 12)
            {
                return $"Good morning, {recipient}!";
            }
            if(time.Hour < 17)
            {
                return $"Good afternoon, {recipient}!";
            }
            return $"Good evening, {recipient}!";        
        }
    }
}
