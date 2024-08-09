using DropShipping.Models;

namespace DropShipping.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UserModel usuario);
        void RemoverSessaoUsuario();
        UserModel BuscarSessaoDoUsuario();
    }
}
