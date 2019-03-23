using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;

namespace todoist.Persistance.Mapping
{
    public class ItemMapper
    {
          public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.Property(x => x.Body).IsRequired();
        }
    }
}