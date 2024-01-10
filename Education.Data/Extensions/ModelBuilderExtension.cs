using Education.Data.Entities;
using Education.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Education.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            //tutor
            var roleId = "8D04DCE2-969A-435D-BBA4-DF3F325983DC";
            var Tutor = "69BD714F-9576-45BA-B5B7-F00649BE00DE";
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Tutor",
                NormalizedName = "Tutor",
                Description = "Teacher"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = Tutor,
                UserName = "Quan",
                Email = "phamlequan118@gmail.com",
                NormalizedEmail = "phamlequan118@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                Image = "/images/pic-1.jpg"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = Tutor
            });

            //Admin
            var roleId2 = "8E04DCE2-970A-435D-BBA4-DF3F325983DC";
            var Admin = "70BD714F-9576-45BA-B5B7-F00649BE00DE";
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId2,
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Adminstrator"
            });

            var hasher2 = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = Admin,
                UserName = "QuanLe",
                Email = "phamlequan@gmail.com",
                NormalizedEmail = "phamlequan@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher2.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                Image = "/images/pic-1.jpg"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId2,
                UserId = Admin
            });




            modelBuilder.Entity<Playlist>().HasData(
                new Playlist()
                {
                    Id = 1,
                    UserId = "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                    Title = "HTML tutorial",
                    Description = "Description",
                    Thumb = "/images/thumb-1.png",
                    DateCreated = DateTime.Now,
                    Status = Status.Active
                },
                    new Playlist()
                    {
                        Id = 2,
                        UserId = "69BD714F-9576-45BA-B5B7-F00649BE00DE",
                        Title = "CSS tutorial",
                        Description = "Description",
                        Thumb = "/images/thumb-2.png",
                        DateCreated = DateTime.Now,
                        Status = Status.Active
                    }
                ); ; 


            modelBuilder.Entity<Content>().HasData(
                new Content()
                {
                    Id = 1,
                    PlaylistId = 1,
                    Title = "HTML tutorial (Part 1)",
                    Description = "cai lmao",
                    Video = "/images/vid-1.mp4",
                    Thumb = "/images/post-1-1.png",
                    DateCreated = DateTime.Now,
                    Status = Status.Active,
                },
                       new Content()
                       {
                           Id = 2,
                           PlaylistId = 1,
                           Title = "HTML tutorial (Part 2)",
                           Description = "cai lmao",
                           Video = "/images/vid-1.mp4",
                           Thumb = "/images/post-1-2.png",
                           DateCreated = DateTime.Now,
                           Status = Status.Active,
                       },
                        new Content()
                        {
                            Id = 3,
                            PlaylistId = 1,
                            Title = "HTML tutorial (Part 3)",
                            Description = "cai lmao",
                            Video = "/images/vid-1.mp4",
                            Thumb = "/images/post-1-3.png",
                            DateCreated = DateTime.Now,
                            Status = Status.Active,
                        },
                               new Content()
                               {
                                   Id = 4,
                                   PlaylistId = 1,
                                   Title = "HTML tutorial (Part 4)",
                                   Description = "cai lmao",
                                   Video = "/images/vid-1.mp4",
                                   Thumb = "/images/post-1-4.png",
                                   DateCreated = DateTime.Now,
                                   Status = Status.Active,
                               },

                               new Content()
                                {
                                    Id = 5,
                                    PlaylistId = 2,
                                    Title = "HTML tutorial (Part 1)",
                                    Description = "cai lmao",
                                    Video = "/images/vid-2.mp4",
                                    Thumb = "/images/post-2-1.png",
                                    DateCreated = DateTime.Now,
                                    Status = Status.Active,
                                },
                       new Content()
                       {
                           Id = 6,
                           PlaylistId = 2,
                           Title = "HTML tutorial (Part 2)",
                           Description = "cai lmao",
                           Video = "/images/vid-2.mp4",
                           Thumb = "/images/post-2-2.png",
                           DateCreated = DateTime.Now,
                           Status = Status.Active,
                       },
                        new Content()
                        {
                            Id = 7,
                            PlaylistId = 2,
                            Title = "HTML tutorial (Part 3)",
                            Description = "cai lmao",
                            Video = "/images/vid-2.mp4",
                            Thumb = "/images/post-2-3.png",
                            DateCreated = DateTime.Now,
                            Status = Status.Active,
                        },
                               new Content()
                               {
                                   Id = 8,
                                   PlaylistId = 2,
                                   Title = "HTML tutorial (Part 4)",
                                   Description = "cai lmao",
                                   Video = "/images/vid-2.mp4",
                                   Thumb = "/images/post-2-4.png",
                                   DateCreated = DateTime.Now,
                                   Status = Status.Active,
                               }

                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
            ContentId = 1,
                    Message = "xin chao casc ban",
                    DateCreated = DateTime.Now,
                },
                 new Comment()
                 {
                     Id = 2,
                     UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                     ContentId = 2,
                     Message = "xin chao casc ban 2",
                     DateCreated = DateTime.Now,
                 }
            );

            modelBuilder.Entity<Like>().HasData(
                new Like()
                {
                    UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                    ContentId = 1,
                },
                 new Like()
                 {
                     UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                     ContentId = 2,
                 }
                );

            modelBuilder.Entity<BookMark>().HasData(
                new BookMark()
                {
                    UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                    PlaylistId = 1
                },
                 new BookMark()
                 {
                     UserId = "70BD714F-9576-45BA-B5B7-F00649BE00DE",
                     PlaylistId = 2
                 }
                ); ;



        }
    }
}
