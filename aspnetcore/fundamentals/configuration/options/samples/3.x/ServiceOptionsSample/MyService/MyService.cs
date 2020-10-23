using Microsoft.Extensions.Options;

namespace ServiceOptionsSample
{
    public class MyService : IMyService
    {
        private readonly MyServiceOptions myServiceOptions;

        public MyService(IOptions<MyServiceOptions> myServiceOptionsAccessor)
        {
            myServiceOptions = myServiceOptionsAccessor.Value;
        }

        public string GetMyValue() =>
            myServiceOptions.MyValue;
    }
}
