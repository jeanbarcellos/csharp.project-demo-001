using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Demo.Domain.Entities;

namespace Demo.Infra.Data.Mappings
{
    public class ProductMapping : EntityMapping<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            // Configure only columns and foreign keys

            builder.Property(o => o.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();

            builder.HasOne(o => o.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId)
                .HasConstraintName(GenerateForeignKeyName("category_id"));

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasColumnName("active")
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnName("value")
                .IsRequired();

            builder.Property(c => c.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnName("image");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp without time zone")
                .IsRequired();
        }
    }
}
