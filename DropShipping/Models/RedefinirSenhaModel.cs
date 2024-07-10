using System.ComponentModel.DataAnnotations;

namespace DropShipping.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Email { get; set; }
    }
}
