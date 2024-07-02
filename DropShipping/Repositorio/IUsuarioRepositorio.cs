using DropShipping.Models;


namespace DropShipping.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UserModel BuscarPorLogin(string login);
        List<UserModel> BuscarTodos();
        UserModel BuscarPorId(int id);
        UserModel Adicionar(UserModel usuario);
        UserModel Atualizar(UserModel usuario);
        bool Apagar(int id);
    }
}
