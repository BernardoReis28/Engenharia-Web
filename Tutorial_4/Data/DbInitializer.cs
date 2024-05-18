using Microsoft.EntityFrameworkCore;
using Tutorial_4.Models;

namespace Tutorial_4.Data
{
    public class DbInitializer
    {
        private Tutorial_4Context _context;

        public DbInitializer(Tutorial_4Context context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Category.Any())
            {
                return;
            }

            var categorias = new Category[]
            {
                new Category {Name = "Programning", Description = "Algoritms and programming area courses"},
                new Category {Name = "Administration", Description = "Public administration and business management courses"},
                new Category {Name = "Communication", Description = "Business and institutional communication course"}
            };

            _context.Category.AddRange(categorias);
            //foreach (var c in categorias)
            //{
            //    _context.Category.Add(c);
            //}
            _context.SaveChanges();
        }
    }
}





    



