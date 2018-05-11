using Microsoft.EntityFrameworkCore;
using NASEB.Library.Entities.Concrete;

namespace NASEB.Library.DAL.Concrete.EF
{
    public class NASEBLibraryDbContext:DbContext
    {
        public NASEBLibraryDbContext(DbContextOptions<NASEBLibraryDbContext> options):base(options)
        {

        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RentHistory> Rents { get; set; }
        public virtual DbSet<UserToken> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBooks>().HasKey(a => new
            {
                a.AuthorID,a.BookID
            });
            modelBuilder.Entity<UserRoles>().HasKey(a => new
            {
                a.UserID,
                a.RoleID
            });
            modelBuilder.Entity<Member>().HasIndex(a => a.TRIDNo).IsUnique();
        }
    }
}
