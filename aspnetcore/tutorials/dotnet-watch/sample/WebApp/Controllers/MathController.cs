using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public static class Calculator
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static int Product(int a, int b)
        {
            // We have an intentional bug here.
            // change to:
            // return a * b; 
            return a + b; 
        }
    }

    [Route("api/[controller]/[action]")]
    public class MathController: Controller
    {
        [HttpGet]
        public string Sum(int a, int b)
        {
            return Calculator.Sum(a, b).ToString();
        }

        [HttpGet]
        public string Product(int a, int b)
        {
            return Calculator.Product(a, b).ToString();
        }
    }
}
