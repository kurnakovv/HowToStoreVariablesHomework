using HowToStoreVariablesHomework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesHomeworkTests.UnitTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Buy_CanBuyProductWithSendCheckByEmail_ProductNameAndTrue()
        {
            Environment.SetEnvironmentVariable("SendCheckByEmail", "true");

            var result = new ProductController().Buy("myTestProduct");

            Assert.Equal("myTestProduct", result.ProductName);
            Assert.True(result.IsCheckSent);

            Environment.SetEnvironmentVariable("SendCheckByEmail", null);
        }

        [Fact]
        public void Buy_CanBuyProductWithSendCheckByEmail_ProductNameAndFalse()
        {
            Environment.SetEnvironmentVariable("SendCheckByEmail", "false");

            var result = new ProductController().Buy("myTestProduct");

            Assert.Equal("myTestProduct", result.ProductName);
            Assert.False(result.IsCheckSent);

            Environment.SetEnvironmentVariable("SendCheckByEmail", null);
        }
    }
}
