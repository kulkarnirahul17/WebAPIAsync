using AsyncWebAPISample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebAPISample.Data.EntityFramework
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<AsyncWebAPISample.Entities.Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public AsyncWebAPISample.Entities.Product GetById(long id)
		{
			throw new NotImplementedException();
		}
	}
}
