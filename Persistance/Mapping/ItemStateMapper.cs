using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;

namespace todoist.Persistance.Mapping
{
    public class ItemStateMapper: IEntityTypeConfiguration<ItemState>
    {
          public void Configure(EntityTypeBuilder<ItemState> builder)
        {
            builder.ToTable("ItemState")
            .Property(x => x.Changed).IsRequired();
        }
    }
}