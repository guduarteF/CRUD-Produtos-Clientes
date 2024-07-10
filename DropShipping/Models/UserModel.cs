using DropShipping.Enums;
using DropShipping.Helper;
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
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get;set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Password == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Password = Password.GerarHash();
            
        }

        public void SetNovaSenha(string novaSenha)
        {
            Password = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Password = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
