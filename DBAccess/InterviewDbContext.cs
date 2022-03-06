using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DBAccess
{
    public class InterviewDbContext : DbContext
    {
        public DbSet<Candidate> Candidstes { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        // configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=InterviewDb; Username=postgres; Password=tony55637;")
            // perform logging (only shows sql command, also show the inserted parameters)
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        // model creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // modelBuilder.Entity<Course>().ToTable("Course");
            // modelBuilder.
        }

    }
}

/*
 ef core setting:

1. 安裝ef core 5.0.14 跟 tools 還有 designs (才能用power shell cli)
2. 安裝Npgsql.EntityFrameworkCore.PostgreSQL
 */