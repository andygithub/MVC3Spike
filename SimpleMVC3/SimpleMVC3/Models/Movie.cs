using System;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace SimpleMVC3.Models
{
    public class Movie
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Date is required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Genre of Movie must be specified")]
        [DisplayName("Genre of Movie")] public string Genre { get; set; }

        [Required(ErrorMessage = "Price Required")]
        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]
        public decimal Price { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }


    }
    
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(p => p.Price).HasPrecision(18, 2);
        }

    }

}