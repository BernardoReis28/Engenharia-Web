using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turno2P1.Models;

    public class DB_al73991 : DbContext
    {
        public DB_al73991 (DbContextOptions<DB_al73991> options)
            : base(options)
        {
        }

        public DbSet<Turno2P1.Models.Jogo> Jogo { get; set; } = default!;
    }
