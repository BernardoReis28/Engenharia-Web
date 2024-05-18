using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste1._1.Models;

namespace Teste1._1.Data
{
    public class DB_al73991Context : DbContext
    {
        public DB_al73991Context (DbContextOptions<DB_al73991Context> options)
            : base(options)
        {
        }

        public DbSet<Teste1._1.Models.Alunos> Alunos { get; set; } = default!;
    }
}
