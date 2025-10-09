using M8MusicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace M8MusicAPI.Mappings;

public class MusicMapping : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.HasKey(x => x.idMusic);
        builder.Property(x => x.idMusic)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.artista)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.genre)
            .IsRequired();
        
    }
}