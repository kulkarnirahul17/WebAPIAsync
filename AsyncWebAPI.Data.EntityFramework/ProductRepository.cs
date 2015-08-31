using AsyncWebAPISample.Data;
using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebAPISample.Data.EntityFramework
{
	public class ProductRepository : EntityFrameworkRepository<Product>, IProductRepository
	{
		public ProductRepository(DbContext context) : base (context)
		{
			
		}
	}
}
