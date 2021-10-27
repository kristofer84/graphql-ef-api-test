using Microsoft.EntityFrameworkCore;
using test_graph.Models;

namespace test_graph
{
    public class AppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(l => l.Id);


            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Superman and Lois"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Game of Thrones"
                },
                new Movie
                {
                    Id = 3,
                    Name = "Avengers: Endgame"
                }
            );

            modelBuilder
                .Entity<Review>()
                //.OwnsMany(m => m.Reviews)
                .HasData(
                new Review
                {
                    Id = 1,
                    Reviewer = "A",
                    Stars = 4,
                    MovieId = 1
                },
                new Review
                {
                    Id = 2,
                    Reviewer = "B",
                    Stars = 5,
                    MovieId = 1
                },
                new Review
                {
                    Id = 3,
                    Reviewer = "A",
                    Stars = 4,
                    MovieId = 2
                },
                new Review
                {
                    Id = 4,
                    Reviewer = "D",
                    Stars = 5,
                    MovieId = 2
                },
                new Review
                {
                    Id = 5,
                    Reviewer = "E",
                    Stars = 3,
                    MovieId = 2
                },
                new Review
                {
                    Id = 6,
                    Reviewer = "F",
                    Stars = 5,
                    MovieId = 2
                },
                new Review
                {
                    Id = 7,
                    Reviewer = "A",
                    Stars = 2,
                    MovieId = 3
                },
                new Review
                {
                    Id = 8,
                    Reviewer = "B",
                    Stars = 1,
                    MovieId = 3
                },
                new Review
                {
                    Id = 9,
                    Reviewer = "G",
                    Stars = 3,
                    MovieId = 3
                },
                new Review
                {
                    Id = 10,
                    Reviewer = "H",
                    Stars = 4,
                    MovieId = 3
                }
            );
        }
    }
}
