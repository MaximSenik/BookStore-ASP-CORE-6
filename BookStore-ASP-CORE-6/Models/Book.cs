using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore_ASP_CORE_6.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int Price { get; set; }
        public int PublisherId { get; set; }
        public DateTime DateAdded { get; set; }
        //Navigation Properties
        public List<Book_Author> Book_Author { get; set; }
        public Publisher Publisher { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
