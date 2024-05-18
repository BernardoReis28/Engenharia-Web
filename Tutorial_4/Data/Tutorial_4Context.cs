using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_4.Models;

namespace Tutorial_4.Data
{
    public class Tutorial_4Context : DbContext
    {
        public Tutorial_4Context (DbContextOptions<Tutorial_4Context> options)
            : base(options)
        {
        }

        public DbSet<Tutorial_4.Models.Category> Category { get; set; } = default!;
    }
}
