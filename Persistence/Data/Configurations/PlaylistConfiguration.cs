using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PlayListConfiguration : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Tracks)
                .WithMany(t => t.PlayLists)
                .HasForeignKey(t => t.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Tracks)
                .WithMany()
                .HasForeignKey(p => p.TrackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
