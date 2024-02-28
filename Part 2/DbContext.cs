//For database session, persisted between service restarts
using Microsoft.EntityFrameworkCore; //object-relation mapper
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectDb
{
    public class ProjectDbContext : DbContext
    {
        //constructing the DbContext along with the tables and relations of the databse 
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options) { }
        public DbSet<Container> Container { get; set; }

        public DbSet<Ship> Ship { get; set; }
        public DbSet<Truck> Truck { get; set; }
    }
}