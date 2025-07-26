using Microsoft.EntityFrameworkCore;
using PokemonChallenge.Models;
using System.Collections.Generic;

namespace PokemonChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Mestre> Mestre { get; set; }
        public DbSet<CapturaPokemon> CapturaPokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyDatabase.db"); // Specify your database file path
        }

    }
}
