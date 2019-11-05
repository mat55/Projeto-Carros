using Microsoft.EntityFrameworkCore;
using Projeto_Carros.Models;

namespace Projeto_Carros
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Carros> Carros { get; set; }
        public DbSet<Revisoes> Revisoes { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carros>().HasKey(d => d.Codigo);
            modelBuilder.Entity<Revisoes>().HasKey(d => d.Codigo);

            modelBuilder.Entity<Carros>().HasMany(d => d.Revisoes);
        }
    }
}
