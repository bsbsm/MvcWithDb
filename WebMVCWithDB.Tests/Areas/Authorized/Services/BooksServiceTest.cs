using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebMVCWithDB.DAL.EFContexts;
using System.Linq;
using WebMVCWithDB.DAL.Entities.Auth.Books;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Books;
using System.Collections.Generic;
using System.Data.Entity;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using System.Collections.ObjectModel;

namespace WebMVCWithDB.Tests.Areas.Authorized.Services
{
    [TestClass]
    public class BooksServiceTest
    {
        IBooksService serv;

        public BooksServiceTest()
        {
            serv = InitializeServiceForTest();
        }
    
        [TestMethod]
        public void GetPageWithBooks_PageAboveZeroSearchNull_NotNullCorrectCount()
        {
            // Arrange
            int page = 1;
            int booksCount = GetQueryableBooks().Count();
            // Act
            var books = serv.GetPageWithBooks(page, null);
            // Assert
            Assert.IsNotNull(books);
            Assert.IsInstanceOfType(books, typeof(PagedList.IPagedList<IMainBook>));
            Assert.AreEqual(booksCount, books.Count);
        }

        [TestMethod]
        public void GetBookById_IdAboveZero_NotNullCorrectIdAndType()
        {
            // Arrange                
            int idBookAboveZero = 4;

            // Act
            var bookAboveZero = serv.GetBookById(idBookAboveZero);

            // Assert
            Assert.IsNotNull(bookAboveZero);
            Assert.IsInstanceOfType(bookAboveZero, typeof(IMainBook));
            Assert.AreEqual(idBookAboveZero, bookAboveZero.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBookById_IdZero_ArgumentException()
        {
            // Arrange                
            int idBookZero = 0;
            //var serv = InitiatedDataForTest();

            // Act
            var bookZero = serv.GetBookById(idBookZero);

            // Assert
            //Expect Exception
        }

        [TestMethod]
        public void GetBookForEditById_IdAboveZero_NotNullCorrectIdAndType()
        {
            // Arrange          
            int idBookAboveZero = 1;
            //var serv = InitiatedDataForTest();

            // Act
            var bookAboveZero = serv.GetBookForEdit(idBookAboveZero);

            // Assert
            Assert.IsNotNull(bookAboveZero);
            Assert.IsInstanceOfType(bookAboveZero, typeof(ICreateBook));
            Assert.AreEqual(idBookAboveZero, bookAboveZero.Id);
        }

        [TestMethod]
        public void GetBookForEditById_IdZero_NotNullCorrectIdAndType()
        {
            // Arrange          
            int idBookZero = 0;
            //var serv = InitiatedDataForTest();

            // Act
            var bookZero = serv.GetBookForEdit(idBookZero);

            // Assert
            Assert.IsNotNull(bookZero);
            Assert.IsInstanceOfType(bookZero, typeof(ICreateBook));
            Assert.AreEqual(idBookZero, bookZero.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBookForEditById_IdNotExist_ArgumentException()
        {
            // Arrange          
            int idBookNotExist = Int32.MaxValue;
            //var serv = InitiatedDataForTest();

            // Act
            var bookNotExist = serv.GetBookForEdit(idBookNotExist);

            // Assert
        }

        [TestMethod]
        public void GetGenres_NotNullCorrectCount()
        {
            // Arrange
            int genresCount = GetQueryableGenres().Count();
            // Act
            var genres = serv.GetGenres();
            // Assert
            Assert.IsNotNull(genres);
            Assert.IsInstanceOfType(genres, typeof(IEnumerable<WEB.Models.General.SimpleDict>));
            Assert.AreEqual(genresCount, genres.Count());
        }

        #region TestInitialize
        private IQueryable<Book> GetQueryableBooks()
        {
            var _books = new ObservableCollection<Book>();

            _books.Add(new Book
            {
                Id = 1,
                Title = "Title_1",
                AuthorId = 1,
                GenreId = 1,
                Description = "Description_1",
                Visible = true,
                Author = new BookAuthor { Id = 1, Name = "Author_1" },
                Genre = new BookGenre { Id = 1, Name = "Genre_1", Visible = true }
            });

            _books.Add(new Book
            {
                Id = 2,
                Title = "Title_2",
                AuthorId = 2,
                GenreId = 2,
                Description = "Description_2",
                Visible = true,
                Author = new BookAuthor { Id = 2, Name = "Author_2" },
                Genre = new BookGenre { Id = 2, Name = "Genre_2", Visible = true }
            });

            _books.Add(new Book
            {
                Id = 3,
                Title = "Title_3",
                AuthorId = 3,
                GenreId = 3,
                Description = "Description_3",
                Visible = true,
                Author = new BookAuthor { Id = 3, Name = "Author_3" },
                Genre = new BookGenre { Id = 3, Name = "Genre_3", Visible = true }
            });

            _books.Add(new Book
            {
                Id = 4,
                Title = "Title_4",
                AuthorId = 4,
                GenreId = 4,
                Description = "Description_4",
                Visible = true,
                Author = new BookAuthor { Id = 4, Name = "Author_4" },
                Genre = new BookGenre { Id = 4, Name = "Genre_4", Visible = true }
            });

            return _books.AsQueryable();
        }

        private IQueryable<BookAuthor> GetQueryableAuthors()
        {
            var _authors = new ObservableCollection<BookAuthor>();

            _authors.Add(new BookAuthor { Id = 1, Name = "Author_1" });
            _authors.Add(new BookAuthor { Id = 2, Name = "Author_2" });
            _authors.Add(new BookAuthor { Id = 3, Name = "Author_3" });
            _authors.Add(new BookAuthor { Id = 4, Name = "Author_4" });

            return _authors.AsQueryable();
        }

        private IQueryable<BookGenre> GetQueryableGenres()
        {
            var _genres = new ObservableCollection<BookGenre>();

            _genres.Add(new BookGenre { Id = 1, Name = "Genre_1", Visible = true });
            _genres.Add(new BookGenre { Id = 2, Name = "Genre_1", Visible = true });
            _genres.Add(new BookGenre { Id = 3, Name = "Genre_1", Visible = true });
            _genres.Add(new BookGenre { Id = 4, Name = "Genre_1", Visible = true });

            return _genres.AsQueryable();
        }

        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> elementsAsQueryable) where T : class
        {
            //var elementsAsQueryable = elements.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return mockDbSet;
        }

        private IBooksService InitializeServiceForTest()
        {
            //Initiated data for test
            var booksQuery = GetQueryableBooks();
            var AuthorsQuery = GetQueryableAuthors();
            var genreQuery = GetQueryableGenres();

            // Create a dbSet
            var mockSetBooks = GetMockDbSet(booksQuery);
            var mockSetAuthors = GetMockDbSet(AuthorsQuery);
            var mockSetGenres = GetMockDbSet(genreQuery);
            // Create a dbContext
            var mockContext = new Mock<ForAllContext>();
            mockContext.Setup(c => c.Books).Returns(mockSetBooks.Object);
            mockContext.Setup(c => c.BookAuthors).Returns(mockSetAuthors.Object);
            mockContext.Setup(c => c.BookGenres).Returns(mockSetGenres.Object);
            // Create service
            var _serv = new BooksService(mockContext.Object);

            return _serv;
        }
        #endregion
    }
}
