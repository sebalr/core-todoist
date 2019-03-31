using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;
using todoist.Entities.Relations;

namespace todoist.Persistance.Mapping
{
    public class ItemCategoryMapper : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.ToTable("ItemCategory")
                .HasKey(x => new { x.CategoryId, x.ItemId });

            // The next part it's not mandatory
            builder.HasOne(x => x.Item).WithMany(x => x.Categories)
                .HasForeignKey(x => x.ItemId);

            builder.HasOne(x => x.Category).WithMany()
                .HasForeignKey(x => x.CategoryId);
        }
    }
}