using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musicians.Models;

namespace Musicians.Configurations
{
    public class MusicLabelConfiguration : IEntityTypeConfiguration<MusicLabel>
    {
        public void Configure(EntityTypeBuilder<MusicLabel> builder)
        {
            builder.HasKey(label => label.IdMusicLabel);

            builder.Property(label => label.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.HasMany(label => label.Albums)
                .WithOne(album => album.MusicLabel);
        }
    }
}