namespace BookStore_ASP_CORE_6.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublisherName { get; set; }
        //Navigation Properties
        public virtual ICollection<Book>? Books { get; set; }
    }
}