using AsyncWebAPISample.Data;
using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AsyncWebAPISample.Controllers
{
	public class ProductsController : ApiController
	{
		private IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public IEnumerable<IProduct> GetAll()
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return _productRepository.GetAll();
		}

		public object GetById(long id)
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return _productRepository.GetById(id);
		}
	}
}
