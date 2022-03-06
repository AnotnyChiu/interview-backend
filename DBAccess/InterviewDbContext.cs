using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBAccess
{
    public class InterviewDbContext : DbContext
    {
        public DbSet<Candidate> Candidstes { get; set; }



        // configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=InterviewDb; Username=postgres; Password=tony55637;");

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