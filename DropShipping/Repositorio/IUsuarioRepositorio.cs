using DropShipping.Models;


namespace DropShipping.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UserModel> BuscarTodos();
        UserModel BuscarPorId(int id);
        UserModel Adicionar(UserModel usuario);
        UserModel Atualizar(UserModel usuario);
        bool Apagar(int id);
    }
}
