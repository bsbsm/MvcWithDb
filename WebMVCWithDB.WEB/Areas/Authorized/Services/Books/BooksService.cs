using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;
using WebMVCWithDB.DAL.EFContexts;
using WebMVCWithDB.WEB.Models.General;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using WebMVCWithDB.DAL.Entities.Auth.Books;

namespace WebMVCWithDB.WEB.Areas.Authorized.Services.Books
{
    public class BooksService : IBooksService
    {
        ForAllContext db;
        public BooksService(ForAllContext context)
        {
            db = context;
        }

        public IPagedList<IMainBook> GetPageWithBooks(int page, ISearchBook search)
        {
            int pageSize = 10;

            if (page < 1) page = 1;

            return GetBooks(search).ToPagedList(page,pageSize);         
        }

        public IMainBook GetBookById (int id)
        {
            if(id > 0)
            {
                ISearchBook search = new SearchBook { Id = id };

                return GetBooks(search).FirstOrDefault();
            }

            throw new ArgumentException("Book ID is not valid. This must be above a zero.");           
        }

        public ICreateBook GetBookForEdit(int id)
        {
            if (id > 0)
            {
                CreateBook book = db.Books.Where(b => b.Id == id && b.Visible == true)
                    .Select(b => new CreateBook
                    {
                        Id = b.Id,
                        AuthorId = b.AuthorId,
                        GenreId = b.GenreId,
                        Description = b.Description
                    }).FirstOrDefault();

                if (book != null)
                    return book;
                else throw new ArgumentException("Book with this ID is not exist.");
            }
            else
            {
                return new CreateBook();
            }
        }

        public bool SaveBook(ICreateBook book, out string errormsg)
        {
            if(book.Id > 0)
            {
                try
                {
                    var record = db.Books.Find(book.Id);
                    record.Title = book.Title;
                    record.GenreId = book.GenreId;
                    record.AuthorId = book.AuthorId;
                    record.Description = book.Description;

                    db.SaveChanges();

                    errormsg = null;
                    return true;
                }
                catch(InvalidOperationException)
                {
                    errormsg = "Ошибка при сохранении. Запись не найдена.";
                    return false;
                }
                
            }
            else
            {
                try
                {
                    var record = new DAL.Entities.Auth.Books.Book();
                    record.Title = book.Title;
                    record.GenreId = book.GenreId;
                    record.AuthorId = book.AuthorId;
                    record.Description = book.Description;

                    db.Books.Add(record);
                    db.SaveChanges();

                    errormsg = null;
                    return true;
                }
                catch (InvalidOperationException)
                {
                    errormsg = "Ошибка при сохранении. Запись не может быть добавлена.";
                    return false;
                }
            }
        }
        /// <summary>
        /// Check in BookTable a book with title
        /// </summary>
        /// <param name="bookTitle">Titile to find</param>
        /// <returns>Return True if book with titile is not exist in db. Else - False.</returns>
        public bool TitleAlreadyExist(string bookTitle)
        {
            return db.Books.Any(b => b.Title.Equals(bookTitle));
        }

        public IEnumerable<SimpleDict> GetAutors()
        {          
            var autors = db.BookAuthors
                .OrderBy(a => a.Name)
                .Select(a => new SimpleDict
                {
                    Key = a.Id,
                    Value = a.Name
                });

            return autors;
        }

        public IEnumerable<SimpleDict> GetGenres()
        {
            var genres = db.BookGenres.Where(g => g.Visible == true)
                .OrderBy(g => g.Name)
                .Select(g => new SimpleDict
                {
                    Key = g.Id,
                    Value = g.Name
                });

            return genres;
        }

        private IEnumerable<IMainBook> GetBooks(ISearchBook search)
        {
            var data = GetBookRecordsQuaryable();

            data = SearchInBook(search, ref data);

            var books = data
                .OrderBy(b => b.Title)
                .Select(b => new MainBook
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author.Name,
                    Genre = b.Genre.Name,
                    Description = b.Description
                });

            return books;
        }

        private IQueryable<Book> GetBookRecordsQuaryable()
        {
            var records = db.Books.Where(b => b.Visible == true);

            return records;
        }

        private IQueryable<Book> SearchInBook(ISearchBook search, ref IQueryable<Book> books)
        {
            if (search != null && books != null)
            {
                if (search.Id > 0) books = books.Where(b => b.Id == search.Id);
                else
                {
                    if (search.AuthorId > 0) books = books.Where(b => b.AuthorId == search.AuthorId);
                    if (search.GenreId > 0) books = books.Where(b => b.GenreId == search.GenreId);
                    if (!String.IsNullOrWhiteSpace(search.Title)) books = books.Where(b => b.Title.Contains(search.Title));
                }
            }

            return books;
        }
    }
}