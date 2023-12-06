using Homework123.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Homework123.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
