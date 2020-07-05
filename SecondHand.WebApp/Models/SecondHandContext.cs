// Sample: based on https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.WebApp.Models
{
    public class SecondHandContext : DbContext
    {
        public SecondHandContext(DbContextOptions<SecondHandContext> options)
           : base(options)
        {
        }

        // Sample: List of tables in the SQL database
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sample: Map the object to the table settings
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string State { get; set; }
    }
}
