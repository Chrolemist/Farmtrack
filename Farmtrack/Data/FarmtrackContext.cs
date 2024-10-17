using Farmtrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace Farmtrack.Data
{
    public class FarmtrackContext : IdentityDbContext
    {
        public FarmtrackContext (DbContextOptions<FarmtrackContext> options)
            : base(options)
        {
        }

        public DbSet<Crop> Crop { get; set; }
    }
}
