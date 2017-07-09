using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Api;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using System.Collections.Generic;
using WebMVCWithDB.WEB.Areas.Authorized.Controllers;
using System.Web.Mvc;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels;

namespace WebMVCWithDB.Tests.Areas.Authorized.Controllers
{
    [TestClass]
    public class NewsControllerTest
    {
        [TestMethod]
        public void Index_NewsTypeIsNull_IsNotNullCorrectTypes()
        {
            //Arrange
            var service = GetService();
            var controller = new NewsController(service);

            //Act
            var result = controller.Index(null);
            var viewModel = ((NewsViewModel)result.Model);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(viewModel, typeof(NewsViewModel));
            Assert.IsNotNull(viewModel.News);
            Assert.IsInstanceOfType(viewModel.News, typeof(IEnumerable<ISingleTypeNews>));
        }

        private IApiService GetService()
        {
            var mockAllNews = new Mock<IEnumerable<ISingleTypeNews>>();

            var mockService = new Mock<IApiService>();
            mockService.Setup(x => x.GetAllNews()).Returns(mockAllNews.Object);

            return mockService.Object;
        }
    }
}
