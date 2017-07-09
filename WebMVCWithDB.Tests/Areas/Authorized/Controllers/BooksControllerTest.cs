using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVCWithDB.WEB.Areas.Authorized.Controllers;
using System.Web.Mvc;
using Moq;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Books;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;
using System.Collections.Generic;
using PagedList;

namespace WebMVCWithDB.Tests.Areas.Authorized.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        IEnumerable<MainBook> books = new MainBook[]
            {
                new MainBook {Id = 1, Title = "Title_1", Author = "Author_1", Genre = "Genre_1", Description = "Description_1" },
                new MainBook {Id = 2, Title = "Title_2", Author = "Author_2", Genre = "Genre_2", Description = "Description_2" },
                new MainBook {Id = 3, Title = "Title_3", Author = "Author_3", Genre = "Genre_3", Description = "Description_3" },
                new MainBook {Id = 4, Title = "Title_4", Author = "Author_4", Genre = "Genre_4", Description = "Description_4" }
            };

        IPagedList<MainBook> pagedBooks;
        int pageNumber = 1;
        int pageSize = 10;

        [TestMethod]
        public void Index_NotNullCorrectTypeAndId()
        {
            // Arrange
            pagedBooks = books.ToPagedList<MainBook>(pageNumber, pageSize);
            SearchBook searchById = new SearchBook();
            Mock<IBooksService> mockRepo = new Mock<IBooksService>();
            mockRepo.Setup(m => m.GetBookById(It.Is<int>(i => i > 0)))
                .Returns(pagedBooks[1]);
            mockRepo.Setup(m => m.GetPageWithBooks(It.Is<int>(i => i > 0), new SearchBook()))
                .Returns(pagedBooks);
            BooksController controller = new BooksController(mockRepo.Object);

            // Act
            var result = controller.Index(new SearchBook(), pageNumber);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(searchById.Id, result.ViewBag.Search.Id);
        }
    }
}
