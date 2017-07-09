using System.Collections.Generic;
using PagedList;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using WebMVCWithDB.WEB.Models.General;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;

namespace WebMVCWithDB.WEB.Areas.Authorized.Services.Books
{
    public interface IBooksService
    {
        IEnumerable<SimpleDict> GetAutors();
        IMainBook GetBookById(int id);
        ICreateBook GetBookForEdit(int id);
        IEnumerable<SimpleDict> GetGenres();
        IPagedList<IMainBook> GetPageWithBooks(int page, ISearchBook search);
        bool SaveBook(ICreateBook book, out string errormsg);
        
        bool TitleAlreadyExist(string bookTitle);
    }
}