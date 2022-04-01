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
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<InterviewStage> InterviewStages { get; set; }

        private readonly string _connectionString = "Host=localhost; Port=5432; Database=InterviewDb; Username=postgres; Password=tony55637;";

        // configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString)
            // perform logging (only shows sql command, also show the inserted parameters)
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        // model creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Course>().ToTable("Course");
            // modelBuilder.
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }

    }
}

/*
 ef core setting:

1. 安裝ef core 5.0.14 跟 tools 還有 designs (才能用power shell cli)
2. 安裝Npgsql.EntityFrameworkCore.PostgreSQL
 */