using DropShipping.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DropShipping.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get;set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
