using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncWebAPISample.Data
{
	public interface IProductRepository
	{
		IEnumerable<IProduct> GetAll();

		IProduct GetById(long id);
	}
}
