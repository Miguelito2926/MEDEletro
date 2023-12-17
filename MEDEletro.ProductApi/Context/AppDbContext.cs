using MEDEletro.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MEDEletro.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //Category
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            //Product
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.Description).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ImageUrl).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.Price).HasPrecision(12,2);

            //Relacionamento um para muitos
            modelBuilder.Entity<Category>().HasMany(g => g.Products).WithOne(c =>
                        c.CategoryName).IsRequired().OnDelete(DeleteBehavior.Cascade);

            //Usando HasData para incluir dados no banco senão houver
            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryId = 1, Name = "Naterial Escolar"},
                 new Category { CategoryId = 2, Name = "Acessórios"}
                );
        }
    }
}
