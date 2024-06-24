using DropShipping.Migrations;
using DropShipping.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DropShipping.Data
{
    public class BancoContext : DbContext
    {
        
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        //public List<Product> Products_List (int id, string name, string description, float price)
        //{
        //    List<Product> produtos = new List<Product>();
        //    Product produto = new Product();
        //    produto.Id = id;
        //    produto.Name = name;
        //    produto.Descrição = description;
        //    produto.Preço = price;
        //    produtos.Add( produto );
        //    Console.WriteLine(produtos);
        //    return produtos;
        //}
    }
}
