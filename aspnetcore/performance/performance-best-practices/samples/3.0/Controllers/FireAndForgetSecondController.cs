using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireAndForgetBad2Controller : Controller
    {
    #region snippet1
        [HttpGet("/fire-and-forget-1")]
        public IActionResult FireAndForget1([FromServices]ContosoDbContext context)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                context.Contoso.Add(new Contoso());
                await context.SaveChangesAsync();
            });

            return Accepted();
        }

        #endregion
    }

    public class Contoso
    {
        public Contoso()
        {
        }

        public void Add (Contoso p) { }
    }

    public class ContosoDbContext
    {
        public  Contoso  Contoso;

        internal Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FireAndForgetGood2Controller : Controller
    {
        #region snippet2
        [HttpGet("/fire-and-forget-3")]
        public IActionResult FireAndForget3([FromServices]IServiceScopeFactory 
                                            serviceScopeFactory)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                await using (var scope = serviceScopeFactory.CreateAsyncScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ContosoDbContext>();

                    context.Contoso.Add(new Contoso());

                    await context.SaveChangesAsync();                                        
                }
            });

            return Accepted();
        }
        #endregion
    }

}
