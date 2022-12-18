using BookApi.Domain.Entities;
using BookApi.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApi.Infrastructure.Context.EntityConfiguration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description);
            builder.Property(e => e.PublishedAt).IsRequired();
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(e => e.DeleteAt);
            builder.Property(e => e.UpdateAt);
        }
    }
}
