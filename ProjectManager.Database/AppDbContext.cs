﻿using Microsoft.EntityFrameworkCore;
using ProjectManager.Database.Configurations;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = "server=127.0.0.1;database=project_manager_db;user=root;password=";

                optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        }
    }
}
