using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tutorial_02.Models
{
    public class Person
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "The field {0} is mandatory")]//Dá erro se o campo estiver vazio
        public string? Name { get; set; }
        
        [DisplayName("Idade")]
        [Required(ErrorMessage = "The field {0} is mandatory")]//Dá erro se o campo estiver vazio
        [Range(18, 100, ErrorMessage = "{0} must be between {1} and {2}")]//Este é um atributo de validação "Range". Ele especifica que a propriedade "Age" deve estar dentro do intervalo de 18 a 100
        public int Age { get; set; }

        // homework
        //Adicione uma nova propriedade à classe Person do tipo Datetime
        [DisplayName("Birth date")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        //Adicione uma nova propriedade à classe Person do tipo string
        [DisplayName("Email address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
