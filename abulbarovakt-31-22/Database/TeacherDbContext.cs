
using abulbarovakt_31_22.Database.Configurations;
using abulbarovakt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace abulbarovakt_31_22.Database
{
    public class TeacherDbContext : DbContext
    {

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeachersConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {

        }
    }
}