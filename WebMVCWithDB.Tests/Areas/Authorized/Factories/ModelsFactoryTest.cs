using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Factory;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;

namespace WebMVCWithDB.Tests.Areas.Authorized.Factories
{
    [TestClass]
    public class ModelsFactoryTest
    {
        [TestMethod]
        public void ModelsFactory_BuildCreateBook_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildCreateBook();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ICreateBook));
        }

        [TestMethod]
        public void ModelsFactory_BuildMainBook_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildMainBook();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IMainBook));
        }

        [TestMethod]
        public void ModelsFactory_BuildSearchBook_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildSearchBook();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ISearchBook));
        }

        [TestMethod]
        public void ModelsFactory_BuildRedditThread_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildRedditThread();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedditThread));
        }

        [TestMethod]
        public void ModelsFactory_BuildTweet_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildTweet();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Tweet));
        }

        [TestMethod]
        public void ModelsFactory_BuildSingleTypeNews_NotNullCorrectType()
        {
            // Arrange      
            IModelsFactory factory = new ModelsFactory();

            //Act
            var result = factory.BuildSingleTypeNews();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ISingleTypeNews));
        }
    }
}
