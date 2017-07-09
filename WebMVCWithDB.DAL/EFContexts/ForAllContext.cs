using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCWithDB.DAL.Entities.Auth.Books;

namespace WebMVCWithDB.DAL.EFContexts
{
    public class ForAllContext : DbContext
    {
        public ForAllContext() : base ("ForAllDatabase")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new BookConfiguration());
        }

        #region Auth.Books
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        #endregion

        

    }
    #region Configurations
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {          
            HasRequired(b => b.Genre).WithMany(g => g.Books).HasForeignKey(b => b.GenreId).WillCascadeOnDelete(false);
            HasRequired(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId).WillCascadeOnDelete(false);
        }
    }
    #endregion
}
