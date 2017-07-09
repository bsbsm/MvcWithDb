using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books
{
    /// <summary>
    /// Main model for a book record
    /// </summary>
    public class MainBook : IMainBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}