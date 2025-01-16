using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace M.E.J_PropertyWebsite.Server.Database
{
	public class ServerDBContext : DbContext
	{
		public ServerDBContext(DbContextOptions<ServerDBContext> options) : base(options)
		{
		}

        public DbSet<Admin> Admins { get; set; }
		public DbSet<Tenant> Tenants { get; set; }
		public DbSet<RentalProperty> RentalProperties { get; set; }

    }
}
