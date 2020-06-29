using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicians.Models;

namespace Musicians.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(album => album.IdAlbum);

            builder.Property(album => album.AlbumName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(album => album.PublishDate)
                .IsRequired();

            builder.HasOne(album => album.MusicLabel)
                .WithMany(label => label.Albums);

            builder.HasMany(album => album.Tracks)
                .WithOne(track => track.Album);
        }
    }
}