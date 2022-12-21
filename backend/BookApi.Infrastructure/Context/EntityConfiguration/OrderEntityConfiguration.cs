using BookApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Infrastructure.Context.EntityConfiguration
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(e => new { e.Id, e.BookId, e.CustomerId });
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Total);
            builder.Property(e => e.Quailty);
            builder.Property(e => e.IsPayment);
            builder.Property(e => e.PaymentDate);
            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(e => e.DeleteAt);
            builder.Property(e => e.UpdateAt);
            builder.HasOne(e => e.Book)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
