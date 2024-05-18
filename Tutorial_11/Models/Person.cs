using System.ComponentModel.DataAnnotations;

namespace Tutorial_11.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
