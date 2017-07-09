using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVCWithDB.WEB.Areas.Authorized.Controllers;
using System.Web.Mvc;

namespace WebMVCWithDB.Tests.Areas.Authorized.Controllers
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void Auth_MainController_Index_NotNullCorrectType()
        {
            // Arrange
            MainController controller = new MainController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
