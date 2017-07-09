using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVCWithDB.DAL.Entities.Auth.Books
{
    [Table("Auth.BookGenres")]
    public class BookGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }      
        public bool Visible { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
