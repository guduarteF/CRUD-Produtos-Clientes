using DropShipping.Data.Map;
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

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<UserModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
