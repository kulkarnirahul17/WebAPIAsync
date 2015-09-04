using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AsyncWebAPISample.Data.EntityFramework
{
	public class DefaultContext : DbContext
	{
		public DefaultContext() : base("ProductsDB") { }

		public DefaultContext(string connectionString)
			: base(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString)
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> Products { get; set; }
	}
}
