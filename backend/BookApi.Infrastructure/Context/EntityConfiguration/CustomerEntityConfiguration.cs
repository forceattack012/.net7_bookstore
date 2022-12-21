using BookApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApi.Infrastructure.Context.EntityConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Address);
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(e => e.DeleteAt);
            builder.Property(e => e.UpdateAt);
            builder.HasMany(e => e.Orders)
                .WithOne(e => e.Customer)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
