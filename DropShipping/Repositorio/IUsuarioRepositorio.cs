using DropShipping.Models;


namespace DropShipping.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UserModel BuscarPorLogin(string login);
        UserModel BuscarPorEmailELogin(string email, string login);
        List<UserModel> BuscarTodos();
        UserModel BuscarPorId(int id);
        UserModel Adicionar(UserModel usuario);
        UserModel Atualizar(UserModel usuario);
        UserModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
