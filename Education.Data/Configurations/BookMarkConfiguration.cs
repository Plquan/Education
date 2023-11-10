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
    public class BookMarkConfiguration : IEntityTypeConfiguration<BookMark>
    {
        public void Configure(EntityTypeBuilder<BookMark> builder)
        {
            builder.ToTable("BookMarks");
            builder.HasKey(x => new { x.UserId, x.PlaylistId });
            builder.HasOne(x => x.AppUser).WithMany(x => x.BookMarks).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Playlist).WithMany(x => x.Bookmarks).HasForeignKey(x => x.PlaylistId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
