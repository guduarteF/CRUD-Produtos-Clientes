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

        public DbSet<UserModel> Usuarios { get; set; }
    }
}
