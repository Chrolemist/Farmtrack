using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmtrack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Farmtrack.Data
{
    public class FarmtrackContext : IdentityDbContext
    {
        public FarmtrackContext (DbContextOptions<FarmtrackContext> options)
            : base(options)
        {
        }

        public DbSet<Crop> Crop { get; set; } = default!;
    }
}
