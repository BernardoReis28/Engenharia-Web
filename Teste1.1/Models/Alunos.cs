using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste1._1.Models
{
    public class Alunos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Numero { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public DateTime? Nascimento { get; set; }
    }
}
