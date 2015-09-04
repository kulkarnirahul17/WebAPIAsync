using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncWebAPI.Factory;
using AsyncWebAPISample.Entities;
using System.Collections.Generic;

namespace AsyncWebAPISample.Data.EntityFramework.Tests
{
	[TestClass]
	public class ProductRepositoryTests
	{
		private  IProductRepository _productRepository;
		
		[TestInitialize]
		public void TestInit()
		{
			_productRepository = _productRepository ?? DefaultFactory<IProductRepository>.Default.Resolve();

			if (_productRepository == null)
				throw new AssertFailedException("Test Intitialization Failed");
		}

		[TestCategory("Integration")]
		[TestMethod]
		public void ProductRepository_GetAll()
		{
			var result = _productRepository.GetAll();
			if (result != null)
				Assert.IsInstanceOfType(result, typeof(IEnumerable<Product>));
		}

		[TestCategory("Integration")]
		[TestMethod]
		public void ProductRepository_GetById_Returns_Null_When_Id_Does_Not_Exist()
		{
			var id = long.MaxValue;
			var result = _productRepository.GetById(id);
			Assert.IsNull(result);
		}

		[TestCategory("Integration")]
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ProductRepository_add_throws_ArgumentNullException_when_item_is_null()
		{
			_productRepository.Add(null);
		}

		[TestCategory("Integration")]
		[TestMethod]		
		public void ProductRepository_add_does_not_throw_exception()
		{
			_productRepository.Add(new Product()
			{
				Name = "Product 1"
			});
		}

	}
}
