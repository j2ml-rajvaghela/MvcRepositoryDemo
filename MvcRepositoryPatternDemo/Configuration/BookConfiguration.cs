using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcRepositoryPatternDemo.Models;

namespace MvcRepositoryPatternDemo.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.HasKey(b => b.bookId);

            builder
                .Property(b => b.bookId)
                .HasColumnName("book_id")
                .HasColumnType("Bigint")
                .IsRequired();

            builder
                .Property(b => b.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(b => b.Auther)
                .HasColumnName("auther")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(b => b.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
