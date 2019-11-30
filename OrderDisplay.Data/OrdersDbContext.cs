using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OrderDisplay.Core;
using OrdersDisplay.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderDisplay.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }


        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(b => b.Date)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>()
                .HasIndex(b => b.LoginName)
                .IsUnique();
            //Unique email makes testing dfifficult.  Consider re-adding when pushing to prod.
            //modelBuilder.Entity<User>()
            //    .HasIndex(b => b.Email)
            //    .IsUnique();
            modelBuilder.Entity<Group>()
                .HasIndex(b => b.Name)
                .IsUnique();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrdersDbContext>
    {
        public OrdersDbContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory()
            //    + "/../OrderDisplay.Api/appsettings.json").Build();
            //var connectionString = configuration.GetConnectionString("DatabaseConnection");

            var configuration = new Configuration();
            var builder = new DbContextOptionsBuilder<OrdersDbContext>();            
            builder.UseSqlServer(configuration.ConnectionString);
            return new OrdersDbContext(builder.Options);
        }
    }
}
