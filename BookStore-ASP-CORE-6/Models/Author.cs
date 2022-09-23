namespace BookStore_ASP_CORE_6.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public List<Book_Author> Book_Author { get; set; }
    }
}
    