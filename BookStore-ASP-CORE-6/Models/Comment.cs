using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore_ASP_CORE_6.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string UserComment { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string? CommentWriterName { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
