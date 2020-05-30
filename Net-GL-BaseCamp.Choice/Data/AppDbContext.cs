using Microsoft.EntityFrameworkCore;
using Net_GL_BaseCamp.Choice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_GL_BaseCamp.Choice.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDiscipline>()
                .HasKey(k => new { k.StudentId, k.DisciplineId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
