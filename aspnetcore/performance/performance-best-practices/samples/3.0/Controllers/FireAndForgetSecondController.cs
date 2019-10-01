using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#if BAD

    public class FireAndForgetSecondController : Controller
    {
    #region snippet1
        [HttpGet("/fire-and-forget-1")]
        public IActionResult FireAndForget1([FromServices]PokemonDbContext context)
        {
            _ = Task.Run(() =>
            {
                await Task.Delay(1000);

                // This closure is capturing the context from the Controller action parameter. This is bad because this work item could run
                // outside of the request scope and the PokemonDbContext is scoped to the request. As a result, this throw an ObjectDisposedException
                context.Pokemon.Add(new Pokemon());
                await context.SaveChangesAsync();
            });

            return Accepted();
        }
    #endregion

    }

#else
    public class FireAndForgetSecondController : Controller
    {
        #region snippet2
        [HttpGet("/fire-and-forget-3")]
        public IActionResult FireAndForget3([FromServices]IServiceScopeFactory serviceScopeFactory)
        {
            // This version of fire and forget adds some exception handling. We're also no longer capturing the PokemonDbContext from the incoming request.
            // Instead, we're injecting an IServiceScopeFactory (which is a singleton) in order to create a scope in the background work item.
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                // Create a scope for the lifetime of the background operation and resolve services from it
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    // This will use PokemonDbContext from the correct scope and the operation will succeed
                    /* FIX THIS
                    var context = scope.ServiceProvider.GetRequiredService<PokemonDbContext>();

                    context.Pokemon.Add(new Pokemon());

                    await context.SaveChangesAsync();
                                        */
                }
            });

            return Accepted();
        }
        #endregion
    }
#endif
}