using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RoyalLibrary.Models.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(b => b.book_id)
                .Metadata
                .IsPrimaryKey();

            builder.Property(b => b.book_id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.first_name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.last_name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.total_copies)
                .IsRequired();

            builder.Property(b => b.copies_in_use)
                .IsRequired();

            builder.Property(b => b.type)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(b => b.isbn)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(b => b.category)
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}