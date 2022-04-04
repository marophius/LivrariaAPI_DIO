using LivrariaAPI_DIO.Data.Config;
using LivrariaAPI_DIO.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAPI_DIO.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
