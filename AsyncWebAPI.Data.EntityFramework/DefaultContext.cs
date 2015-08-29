using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AsyncWebAPISample.Data.EntityFramework
{
	public class DefaultContext : DbContext
	{
		public DefaultContext(string nameOrConnectionString)
			:base(nameOrConnectionString)
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
