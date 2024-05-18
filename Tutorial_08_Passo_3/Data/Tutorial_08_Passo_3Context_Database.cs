using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_08_Passo_3.Models;

    public class Tutorial_08_Passo_3Context_Database : DbContext
    {
        public Tutorial_08_Passo_3Context_Database (DbContextOptions<Tutorial_08_Passo_3Context_Database> options)
            : base(options)
        {
        }

        public DbSet<Tutorial_08_Passo_3.Models.User> User { get; set; } = default!;
    }
