namespace DropShipping.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public float Preço { get; set; }
        
        public int? UsuarioId { get; set; }

        public UserModel? Usuario { get; set; }
    }
}
