using Tutorial_05.Models;

namespace Tutorial_05.Data
{
    public class DbInitializer
    {
        private Tutorial_05Context _context;

        public DbInitializer(Tutorial_05Context context)
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

            var categorias = new Category[]{
                new Category {Name = "Programning", Description = "Algoritms and programming area courses"},
                new Category {Name = "Administration", Description = "Public administration and business management courses"},
                new Category {Name = "Communication", Description = "Business and institutional communication course"}
            };

            //_context.Category.AddRange(categorias);
            foreach (var c in categorias)
            {
                _context.Category.Add(c);
            }
            _context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name="Web Engineering",
                    Description = "Creating new sites using ASP.NET",
                    Cost = 50, Credits = 6,
                    CategoryId = categorias.Single(c => c.Name == "Programming").Id
                },

                new Course
                {
                    Name = "Strategic Leadership and Management",
                    Description = "Leadership and Business Skill for Immediate Impact.",
                    Cost = 100, Credits = 6,
                    Category = categorias.Single(c => c.Name == "Administration")
                },

                new Course
                {
                    Name = "Master in Corporate Communication",
                    Description = "This Master in Corporate Communication will provide required to organize a Communication Department.",
                    Cost = 80,Credits = 10,
                    Category = categorias.Single(c => c.Name == "Communication")
                }
            };
            _context.Course.AddRange(courses);
            _context.SaveChanges();

        }
    }
}
