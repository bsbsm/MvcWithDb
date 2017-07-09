using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVCWithDB.DAL.Entities.Auth.Books
{
    [Table("Auth.Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public bool Visible { get; set; }

        //Navigate properties
        public virtual BookGenre Genre { get; set; }
        public virtual BookAuthor Author { get; set; }
    }
}
