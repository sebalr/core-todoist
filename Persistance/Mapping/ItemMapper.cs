using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;

namespace todoist.Persistance.Mapping
{
    public class ItemMapper: IEntityTypeConfiguration<Item>
    {
          public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item")
            .Property(x => x.Body).IsRequired();
        }
    }
}