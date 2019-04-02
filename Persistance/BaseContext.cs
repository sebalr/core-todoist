using Microsoft.EntityFrameworkCore;
using todoist.Infraestructure.Entities;
using todoist.Persistance.Mapping;

namespace todoist.Persistance
{

    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new ItemMapper());
            modelBuilder.ApplyConfiguration(new CategoryMapper());
            modelBuilder.ApplyConfiguration(new ItemCategoryMapper());
        }

    }
}