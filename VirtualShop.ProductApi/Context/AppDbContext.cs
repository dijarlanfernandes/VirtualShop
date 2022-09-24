using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {}
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(c=>c.CategoryId);

            builder.Entity<Product>().Property(c =>c.Name)
                .HasMaxLength(100).IsRequired();

            builder.Entity<Category>().HasMany(p => p.Products)
                .WithOne(c => c.Category).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
