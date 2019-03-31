using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoist.Entities;

namespace todoist.Persistance.Mapping
{
    public class CategoryMapper: IEntityTypeConfiguration<Category>
    {
          public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category")
            .Property(x => x.Name).IsRequired();
        }
    }
}