using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCWithDB.DAL.EFContexts;
using WebMVCWithDB.DAL.Entities.Auth.Books;

namespace WebMVCWithDB.Tests.Areas.Authorized.Services
{
    public class MockDbContext
    {
        public MockDbContext()
        {
            Books = new Book[]
            {
                new Book {Id = 1, Title = "Title_1", Author = new BookAuthor {Name = "Author_1" }, Genre = new BookGenre {Name = "Genre_1" }, Description = "Description_1" },
                new Book {Id = 2, Title = "Title_2", Author = new BookAuthor {Name = "Author_2" }, Genre = new BookGenre {Name = "Genre_2" }, Description = "Description_2" },
                new Book {Id = 3, Title = "Title_3", Author = new BookAuthor {Name = "Author_3" }, Genre = new BookGenre {Name = "Genre_3" }, Description = "Description_3" },
                new Book {Id = 4, Title = "Title_4", Author = new BookAuthor {Name = "Author_4" }, Genre = new BookGenre {Name = "Genre_4" }, Description = "Description_4" }
            }.AsQueryable();

            BookGenres = new BookGenre[]
           {
                new BookGenre {Id = 1, Name = "Genre_1", Visible = true },
                new BookGenre {Id = 2, Name = "Genre_2",Visible = true },
                new BookGenre {Id = 3, Name = "Genre_3",Visible = true },
                new BookGenre {Id = 4, Name = "Genre_4",Visible = true }
           }.AsQueryable();

            BookAuthors = new BookAuthor[]
         {
                new BookAuthor {Id = 1, Name = "Author_1" },
                new BookAuthor {Id = 2, Name = "Author_2" },
                new BookAuthor {Id = 3, Name = "Author_3" },
                new BookAuthor {Id = 4, Name = "Author_4" }
         }.AsQueryable();
            
        }
        
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookGenre> BookGenres { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
    }
}
