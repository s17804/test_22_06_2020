using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicians.Models;

namespace Musicians.Configurations
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(track => track.IdTrack);

            builder.Property(track => track.TrackName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(track => track.Duration)
                .IsRequired();

            builder.HasOne(track => track.Album)
                .WithMany(album => album.Tracks);

            builder.HasMany(track => track.MusicianTracks)
                .WithOne(musicianTrack => musicianTrack.Track);
        }
    }
}