using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Api;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Factory;
using Moq;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;

namespace WebMVCWithDB.Tests.Areas.Authorized.Services
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ApiServiceTest
    {
        IApiService serv;
        Mock<IModelsFactory> mockFactory;
        Mock<ISingleTypeNews> mockNews;
        
        public ApiServiceTest()
        {
            mockFactory = GetMockFactory();
            serv = new ApiService(mockFactory.Object);
            
        }      

        [TestMethod]
        public void GetAllNews_NotNullCorrectTypeAndCount()
        {
            //Arrange
            var newsTypeCount = (Enum.GetNames(typeof(NewsTypes))).Length;

            //Act
            var news = serv.GetAllNews();
            var newsCount = GetNewsCount(news);

            //Assert
            Assert.IsNotNull(news);
            Assert.IsInstanceOfType(news, typeof(IEnumerable<ISingleTypeNews>));
            Assert.AreEqual(newsTypeCount, newsCount);
        }

        [TestMethod]
        public void GetNews_FirstNewsType_NotNullCorrectType()
        {
            //Arrange
            var firtNewsType = (NewsTypes)0;

            //Act
            var news = serv.GetNews(firtNewsType);

            //Assert
            Assert.IsNotNull(news);
            Assert.IsInstanceOfType(news, typeof(ISingleTypeNews));
        }

        private Mock<IModelsFactory> GetMockFactory()
        {
            InitFactoryReturnObject();

            mockFactory = new Mock<IModelsFactory>();       
            mockFactory.Setup(x => x.BuildSingleTypeNews()).Returns(mockNews.Object);

            return mockFactory;
        }

        private void InitFactoryReturnObject()
        {
            mockNews = new Mock<ISingleTypeNews>();
            mockNews.Setup(x => x.Name).Returns("News1");
        }

        private int GetNewsCount(IEnumerable<ISingleTypeNews> source)
        {
            int count = 0;
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                    count++;
            }
            return count;
        }
    }
}
