using System.Web.Mvc;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces
{
    public interface ICreateBook
    {
        int AuthorId { get; set; }
        string Description { get; set; }
        int GenreId { get; set; }
        int Id { get; set; }
        string Title { get; set; }

        void Validate(ModelStateDictionary ms);
    }
}