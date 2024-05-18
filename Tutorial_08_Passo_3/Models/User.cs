using System.ComponentModel.DataAnnotations;

namespace Tutorial_08_Passo_3.Models
{
    public class User
    {
            [Key]
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
