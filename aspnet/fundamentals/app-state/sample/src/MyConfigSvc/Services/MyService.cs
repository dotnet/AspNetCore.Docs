namespace MyConfigSvc.Services
{
    public static class MyService
    {
        public static void InitializeService(MyConfigService myService)
        {
            if (myService.Discount != 0)
            {
                return;
            }
            myService.Discount = 10;
            myService.Theme = "fun";
        }
    }
}
