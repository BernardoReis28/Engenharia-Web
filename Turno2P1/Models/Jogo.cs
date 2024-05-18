using System.ComponentModel.DataAnnotations;

namespace Turno2P1.Models
{
    public class Jogo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(256, ErrorMessage = "Maximo 256 caracteres")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "Só jpg files")]
        public string? Foto { get; set; }

        [Range(0, 10)]
        [Display(Name = "Pontuação")]
        public int Pontuacao { get; set; } = 0;

        public Boolean Estado { get; set; } = true;
    }
}
