using BookStore_ASP_CORE_6.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasOne(a => a.Book).WithMany(c => c.Comments);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.AuthorId);
            //    modelBuilder.Entity<Categories>().HasData(
            //        new { ID = 5, Name = "Iguanas", CategoryPicture = @"\Assets\CategoriesI-icons\iguana-icon.jpg" }
            //    );
            //    modelBuilder.Entity<Books>().HasData(
            //        new { ID = 8, Name = "Bob", Age = 3, PictureName = @"\Assets\Pets\Iguanas\Bob.jpg", Description = "Not doing much, mostly being lazy", CategoryName = "Iguanas", Price = 10 }
            //    );
            //    modelBuilder.Entity<Comments>().HasData(
            //       new { ID = 11, Comment = "What a massive rabbit!", AnimalID = 6, CommentWriterName = "Tom", CommentDate = DateTime.Now }
            //    );
        }
    }
}
