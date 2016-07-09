using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using OnlineStore.Domain.Abstract;
using OnlineStore.Domain.Entities;
using OnlineStore.Controllers;

namespace OnlineStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID=1,Name="P1"},
                new Product { ProductID=2,Name="P2"},
                new Product { ProductID=3,Name="P3"},
                new Product { ProductID=4,Name="P4"},
                new Product { ProductID=5,Name="P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List("",2).Model;
            Product[] prodArry = result.ToArray();
            Assert.IsTrue(prodArry.Length==2);
            Assert.AreEqual(prodArry[0],"P4");
            Assert.AreEqual(prodArry[1], "P5");
        }
    }
}
