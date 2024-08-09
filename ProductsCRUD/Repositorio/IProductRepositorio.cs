using DropShipping.Models;

namespace DropShipping.Repositorio
{
    public interface IProductRepositorio
    {
        List<ProductModel> BuscarTodos(int usuarioId);
        ProductModel BuscarPorId(int id);
        ProductModel Adicionar(ProductModel produto);
        ProductModel Atualizar(ProductModel produto);
        ProductModel Detalhes(ProductModel produto);
        bool Apagar(int id);
    }
}
