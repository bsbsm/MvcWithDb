using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books
{
    /// <summary>
    /// Search model for a book record
    /// </summary>
    public class SearchBook: ISearchBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}