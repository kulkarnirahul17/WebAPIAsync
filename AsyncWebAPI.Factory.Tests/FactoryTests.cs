using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncWebAPI.Factory;

namespace AsyncWebAPI.Factory.Tests
{
	[TestClass]
	public class FactoryTests
	{
		[TestInitialize]
		public void TestInit()
		{
		
		}

		[TestCategory("Unit")]
		[TestMethod]
		public void Factory_Resolves_Unity_Configured_Types()
		{
			var testClassInstance = DefaultFactory<ITestClass1>.Default.Resolve();
			Assert.IsInstanceOfType(testClassInstance, typeof(TestClass1));
		}
	}
}
