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
		private IProductRepository _productRepository;

		[TestInitialize]
		public void TestInit()
		{
			_productRepository = DefaultFactory<IProductRepository>.Default.Resolve();
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
		public void ProductRepository_GetById_Returns_Null_When_Id_Does_Not()
		{
			var id = long.MaxValue;
			var result = _productRepository.GetById(id);
			Assert.IsNull(result);
		}
	}
}
