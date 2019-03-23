using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;

namespace todoist.Persistance.Mapping
{
    public class ItemStateMapper
    {
          public void Configure(EntityTypeBuilder<ItemState> builder)
        {
            builder.ToTable("ItemState");
            builder.Property(x => x.Changed).IsRequired();
        }
    }
}