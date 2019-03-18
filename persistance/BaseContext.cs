using Microsoft.EntityFrameworkCore;
using todoist.infraestructure.entities;
using todoist.persistance.mappers;

namespace todoist.persistance
{

    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapper());
        }

    }
}