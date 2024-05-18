using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tutorial_03.Models
{
    public class FileViewModel
    {
        [Required]// garante que o Name nao é nulo
        [RegularExpression(@"^.+\.([pP][dD][fF])$", ErrorMessage = "Only Pdf files")]// verifica se é um pdf
        public string? Name { get; set; }

        [DisplayName("Size in Bytes")]
        public long Size { get; set; }
    }
}
