using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Order;
using OrderNamespace = OrderService.Domain.Order;

namespace OrderService.Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<OrderNamespace.Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrderTable(builder);
        ConfigureOrderItemTable(builder);
        ConfigureFailureMessageTable(builder);
    }

    private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).HasConversion(
            orderId => orderId.Value,
            value => new OrderNamespace.ValueObjects.OrderId(value)
        );

        // builder.OwnsOne(o => o.Id, sa => sa.Property(a => a.Value).HasColumnName("order_id"));
        // builder.Property(o => o.Id).HasColumnName("order_id");
    }

    private void ConfigureOrderItemTable(EntityTypeBuilder<Order> builder)
    {
        // builder.OwnsMany(o => o.Items, sb =>
        // {
        //     sb.ToTable("OrderItem");

        // sb.WithOwner().HasForeignKey("order_id");
        // });
    }

    private void ConfigureFailureMessageTable(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(f => f.Id);

        builder.OwnsMany(o => o.FailureMessages, sb =>
        {
            sb.ToTable("failure_messages");

            sb.WithOwner().HasForeignKey("order_id");
        });
    }
}