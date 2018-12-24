using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public double Price { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Rate> Rates { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageName { get; set; }
        public string Biography { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public enum RatePoint
    {
        Worst,
        Bad,
        Good,
        Great,
        Perfect
    }
    public class Rate
    {
        public int Id  { get; set; }
        public RatePoint RatePoint { get; set; }
        [MaxLength(length:255, ErrorMessage = "Your comment must not be longer than 255 characters")]
        public string Comment { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("DefaultConnection")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }

}