using DropShipping.Data;
using DropShipping.Models;
using DropShipping.Repositorio;

namespace DropShipping.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext context)
        {
            this._context = context;
        }

        public UserModel Adicionar(UserModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UserModel usuarioDB = BuscarPorId(id);

            if(usuarioDB == null) throw new Exception("Houve um erro na deleção do usuário");

                _context.Usuarios.Remove(usuarioDB);
                _context.SaveChanges();

                return true;
        }

        public UserModel Atualizar(UserModel usuario)
        {
            UserModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuario.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;


            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;

        }
        public UserModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);

        }

       
        public List<UserModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
