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

		public ProductsController()
		{
			_productRepository = AsyncWebAPI.Factory.DefaultFactory<IProductRepository>.Default.Resolve();
		}

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
		[Route("api/products")]
		public IHttpActionResult GetAll()
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return Ok(_productRepository.GetAll());
		}

		/// <summary>
		/// Gets the by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Product repository is null</exception>
		// api/Products/5
		[Route("api/products/{id}")]
		public IHttpActionResult GetById(long id)
		{
			if (_productRepository == null)
				throw new InvalidOperationException("Product repository is null");

			return Ok(_productRepository.GetById(id));
		}

		[Route("api/products")]
		[HttpPost]
		public IHttpActionResult AddProduct([FromBody] Product product)
		{
			_productRepository.Add(product);
			_productRepository.SaveChanges();
			return Ok();
		}
	}
}
