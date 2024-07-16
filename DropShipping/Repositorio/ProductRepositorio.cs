using DropShipping.Data;
using DropShipping.Models;

namespace DropShipping.Repositorio
{
    public class ProductRepositorio : IProductRepositorio
    {
        private readonly BancoContext _context;
        public ProductRepositorio(BancoContext context)
        {
            this._context = context;
        }

        public ProductModel Adicionar(ProductModel produto)
        {
            _context.Products.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool Apagar(int id)
        {
           ProductModel productDB = BuscarPorId(id);

            if (productDB == null) throw new Exception("Houve um erro na deleção do produto");

            _context.Products.Remove(productDB);
            _context.SaveChanges();

            return true;
        }

        public ProductModel Atualizar(ProductModel produto)
        {
            ProductModel productDB = BuscarPorId(produto.Id);

            if (productDB == null) throw new Exception("Houve um erro na deleção do produto");

            productDB.Nome = produto.Nome;
            productDB.Preço = produto.Preço;
            productDB.Descrição = produto.Descrição;

            _context.Products.Update(productDB);
            _context.SaveChanges();

            return productDB;

        }

        public ProductModel BuscarPorId(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductModel> BuscarTodos(int usuarioId)
        {
            return _context.Products.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ProductModel Detalhes(ProductModel produto)
        {
            throw new NotImplementedException();
        }
    }
}
