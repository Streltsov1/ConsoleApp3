using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp3
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { Id = 1, Name = "Ukraine" },
                new Country() { Id = 2, Name = "Italy" },
                new Country() { Id = 3, Name = "Great Britain" },
            });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist() { Id = 1, Name = "GEWfwefw", Surname ="EWtiowfe", CountryId = 1 },
                new Artist() { Id = 2, Name = "EWGwfw" , Surname =" Fewfwf", CountryId = 1 },
                new Artist() { Id = 3, Name = "Jtrhr" , Surname ="ewoirfujw", CountryId = 2},
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() { Id = 1, Name = "First"},
                new Genre() { Id = 2, Name = "Second"},
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album() { Id = 1, Name = "Good Album", Year = 2020, GenreId = 2, ArtistId = 1},
                new Album() { Id = 2, Name = "Bad Album", Year = 2021 , GenreId = 1, ArtistId = 2},
            });

            Tracks firstTrack = new Tracks() { Id = 1, Name = "First track", Duration = 157, AlbumId = 1 };
            Tracks secondTrack = new Tracks() { Id = 2, Name = "Second track", Duration = 190, AlbumId = 1 };
            modelBuilder.Entity<Tracks>().HasData(new Tracks[]
            {
                firstTrack, secondTrack
            }) ;
            modelBuilder.Entity<Category>().HasData(new Category[]
           {
                new Category() { Id = 1, Name = "Category"},
           });
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

    }
}
