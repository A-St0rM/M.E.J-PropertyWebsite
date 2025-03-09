using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace M.E.J_PropertyWebsite.Server.Database
{
    public class AzureDBContext : DbContext
    {
        public AzureDBContext(DbContextOptions<AzureDBContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<RentalProperty> RentalProperty { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<RentalHistory> rentalHistories { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<WaitingList> WaitlingList { get; set; }
    }
}
