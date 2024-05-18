using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_05.Models;

namespace Tutorial_05.Data
{
    public class Tutorial_05Context : DbContext
    {
        public Tutorial_05Context (DbContextOptions<Tutorial_05Context> options)
            : base(options)
        {
        }

        public DbSet<Tutorial_05.Models.Category> Category { get; set; } = default!;

        public DbSet<Tutorial_05.Models.Course>? Course { get; set; }
    }
}
