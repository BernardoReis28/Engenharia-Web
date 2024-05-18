using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_11.Models;

namespace Tutorial_11.Data
{
    public class Tutorial_11Context : DbContext
    {
        public Tutorial_11Context (DbContextOptions<Tutorial_11Context> options)
            : base(options)
        {
        }

        public DbSet<Tutorial_11.Models.Person> Person { get; set; } = default!;
    }
}
