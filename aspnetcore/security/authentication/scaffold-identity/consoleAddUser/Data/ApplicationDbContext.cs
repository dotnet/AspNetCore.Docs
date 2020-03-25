using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class AppDbCntx : IdentityDbContext
    {
        public AppDbCntx(DbContextOptions<AppDbCntx> options)
            : base(options)
        {
        }
    }
}
