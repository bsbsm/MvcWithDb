
using System;
using System.Web.Mvc;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Books
{
    /// <summary>
    /// Create model for a book record
    /// </summary>
    public class CreateBook : ICreateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }       
        public string Description { get; set; }
        public int GenreId { get; set; }

        public void Validate(ModelStateDictionary ms)
        {
            if (AuthorId < 1) ms.AddModelError("AuthorId", "Please choose a author");
            if (GenreId < 1) ms.AddModelError("GenreId", "Please choose a genre");
            if (String.IsNullOrWhiteSpace(Title)) ms.AddModelError("Title", "Please enter a book title");
        }
    }
}