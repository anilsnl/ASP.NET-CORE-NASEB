namespace NASEB.Library.Entities.Concrete
{
    public class AuthorBooks
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
