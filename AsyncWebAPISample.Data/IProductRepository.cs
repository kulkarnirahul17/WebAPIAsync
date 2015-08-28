using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncWebAPISample.Data
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAll();

		Product GetById(long id);
	}
}
