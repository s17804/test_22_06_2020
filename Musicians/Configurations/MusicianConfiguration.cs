using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicians.Models;

namespace Musicians.Configurations
{
    public class MusicianConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.HasKey(musician => musician.IdMusician);

            builder.Property(musician => musician.FirstName)
                .IsRequired().HasMaxLength(30);
            
            builder.Property(musician => musician.LastName)
                .IsRequired().HasMaxLength(50);
            
            builder.Property(musician => musician.NickName)
                .IsRequired().HasMaxLength(20);

            builder.HasMany<MusicianTrack>(musician => musician.MusicianTracks)
                .WithOne(track => track.Musician);
        }
    }
}