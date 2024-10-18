using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;


namespace OnlineShopping.DataAccess.Repository
{
    public partial class EshopContext 
    {
        public DbSet<ResponseCode> ResponseCodes { get; set; }
        public DbSet<LoadDropdownModel> LoadDropdownModels { get; set; }
        public DbSet<Category> CategorModel { get; set; }

        public DbSet<SubCategory> SubCatList { get; set; }
        public DbSet<ItemModel> ItemList { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Carts { get; set; }
      
        public DbSet<ProductDetails> ProductDetail { get; set; }

        public DbSet<PasswordHashModel> PasswordHashModel { get; set; }
        public DbSet<CartCount> TotalCartCount { get; set; }
        public DbSet<OrderDetailResult> OrderDetailResult { get; set; }
        public DbSet<DashboardModel> DashboardModels { get; set; }

        




        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponseCode>(entity =>
            {
                entity.HasNoKey();
                // Additional configuration for your keyless entity
            });
            modelBuilder.Entity<LoadDropdownModel>(entity =>
            {
                entity.HasNoKey();
                // Additional configuration for your keyless entity
            });
            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasNoKey();
                // Additional configuration for your keyless entity
            });
            modelBuilder.Entity<ItemModel>(entity =>
            {
                entity.HasNoKey();
                // Additional configuration for your keyless entity
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();
                // Additional configuration for your keyless entity
            });
            modelBuilder.Entity<Cart>(entity => {
                entity.HasNoKey();

            });

            modelBuilder.Entity<ProductDetails>(entity => {
                entity.HasNoKey();

            });
            modelBuilder.Entity<PasswordHashModel>(entity => {
                entity.HasNoKey();

            });
            modelBuilder.Entity<CartCount>(entity => {
                entity.HasNoKey();

            });
            modelBuilder.Entity<OrderDetailResult>(entity => {
                entity.HasNoKey();

            });
            modelBuilder.Entity<DashboardModel>(entity => {
                entity.HasNoKey();

            });
        }

    }

  
}