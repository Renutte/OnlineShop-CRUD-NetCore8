
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<StoreProduct> StoreProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreProduct>()
                .HasKey(sp => new { sp.StoreId, sp.ProductId });

            modelBuilder.Entity<StoreProduct>()
                .HasOne(sp => sp.Store)
                .WithMany(s => s.StoreProducts)
                .HasForeignKey(sp => sp.StoreId);

            modelBuilder.Entity<StoreProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.StoreProducts)
                .HasForeignKey(sp => sp.ProductId);
        }
    }
}
