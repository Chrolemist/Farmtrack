﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmtrack.Controllers;

namespace Farmtrack.Data
{
    public class FarmtrackContext : DbContext
    {
        public FarmtrackContext (DbContextOptions<FarmtrackContext> options)
            : base(options)
        {
        }

        public DbSet<Farmtrack.Controllers.Crop> Crop { get; set; } = default!;
    }
}