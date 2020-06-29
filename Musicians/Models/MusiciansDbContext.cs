using Microsoft.EntityFrameworkCore;
using Musicians.Configurations;

namespace Musicians.Models
{
    public class MusiciansDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected MusiciansDbContext()
        {
        }

        public MusiciansDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new MusicianConfiguration());
            modelBuilder.ApplyConfiguration(new MusicianTrackConfiguration());
            modelBuilder.ApplyConfiguration(new MusicLabelConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());
        }
    }
}