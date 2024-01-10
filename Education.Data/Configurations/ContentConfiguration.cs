using Education.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
           builder.ToTable("Contents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Video).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Thumb).HasMaxLength(300).IsRequired();
            builder.HasOne(x => x.Playlist).WithMany(x => x.Contents).HasForeignKey(x => x.PlaylistId);
        }
    }
}
