namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces
{
    public interface IMainBook
    {
        int Id { get; set; }
        string Author { get; set; }
        string Description { get; set; }
        string Genre { get; set; }
        string Title { get; set; }
    }
}