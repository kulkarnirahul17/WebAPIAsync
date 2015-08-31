using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncWebAPISample.Controllers;
using Moq;
using AsyncWebAPISample.Entities;
using System.Collections.Generic;
using AsyncWebAPISample.Data;
using Moq;

namespace AsyncWebAPISample.Tests
{
	[TestClass]
	public class ProductsControllerTests
	{
		private ProductsController _controller;
		private Mock<IProductRepository> _mockProductRepository;

		[TestInitialize]
		public void TestInit()
		{
			_mockProductRepository = new Moq.Mock<IProductRepository>();
			_controller = new ProductsController(_mockProductRepository.Object);
		}

		[TestCategory("Unit")]
		[TestMethod]
		public void Can_Get_All_Products()
		{
			_mockProductRepository.Setup(x => x.GetAll()).Returns(It.IsAny<IEnumerable<Product>>());
			var products = _controller.GetAll();

			_mockProductRepository.Verify(x => x.GetAll(), Times.Once);
		}

		[TestCategory("Unit")]
		[TestMethod]
		public void Get_Product_By_Id_Returns_Product_With_The_Same_Id()
		{
			long id = 23;
			_mockProductRepository.Setup(repo => repo.GetById(id)).Returns(Moq.It.Is<Product>(x=> x.Id == id));

			var result = _controller.GetById(id);
			_mockProductRepository.VerifyAll();
		}
	}
}
