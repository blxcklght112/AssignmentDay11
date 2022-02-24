using Microsoft.EntityFrameworkCore;
using Day11.Entities;

namespace Day11.DB
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasMany<Product>(p => p.Products)
                        .WithOne(c => c.Category)
                        .HasForeignKey(p => p.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Bike"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "Yamaha",
                    Manufacture = "Ha Noi"
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Suzuki",
                    Manufacture = "Ho Chi Minh"
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductName = "Honda",
                    Manufacture = "Da Nang"
                }
            );

        }
    }
}