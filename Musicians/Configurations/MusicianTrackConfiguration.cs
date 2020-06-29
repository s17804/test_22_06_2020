using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicians.Models;

namespace Musicians.Configurations
{
    public class MusicianTrackConfiguration : IEntityTypeConfiguration<MusicianTrack>
    {
        public void Configure(EntityTypeBuilder<MusicianTrack> builder)
        {
            builder.HasKey(track => track.IdMusicianTrack);

            builder.HasOne(musicTrack => musicTrack.Musician)
                .WithMany(musician => musician.MusicianTracks);
            
            builder.HasOne(musicTrack => musicTrack.Track)
                .WithMany(track =>  track.MusicianTracks);
        }
    }
}