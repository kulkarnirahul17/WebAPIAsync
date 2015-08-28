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

		/// <summary>
		/// Initializes a new instance of the <see cref="ProductsController"/> class.
		/// </summary>
		/// <param name="productRepository">The product repository.</param>
		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		/// <summary>
		/// Gets all Products.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Product repository is null</exception>
		// api/Products/
		public IEnumerable<Product> GetAll()
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return _productRepository.GetAll();
		}

		/// <summary>
		/// Gets the by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Product repository is null</exception>
		// api/Products/5
		public object GetById(long id)
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return _productRepository.GetById(id);
		}
	}
}
