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
        public IActionResult FireAndForget1([FromServices]PokemonDbContext context)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                context.Pokemon.Add(new Pokemon());
                await context.SaveChangesAsync();
            });

            return Accepted();
        }

        #endregion
    }

    public class Pokemon
    {
        public Pokemon()
        {
        }

        public void Add (Pokemon p) { }
    }

    public class PokemonDbContext
    {
        public  Pokemon  Pokemon;

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

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PokemonDbContext>();

                    context.Pokemon.Add(new Pokemon());

                    await context.SaveChangesAsync();                                        
                }
            });

            return Accepted();
        }
        #endregion
    }

}