using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...;initial Catalog = MultiShopOrderDb;integrated security=ture;");
        }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
