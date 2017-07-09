namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces
{
    public interface ISearchBook
    {
        int AuthorId { get; set; }
        int GenreId { get; set; }
        int Id { get; set; }
        string Title { get; set; }
    }
}