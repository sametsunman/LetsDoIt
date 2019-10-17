using LDI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=tcp:asnus.database.windows.net,1433;Database=LDI;User ID=asnus;Password=Cask2275*;Encrypt=true;Connection Timeout=30;");
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=LDI;Trusted_Connection=true;");
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Channel> Channels { get; set; }
        DbSet<Content> Contents { get; set; }
        DbSet<Media> Medias { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChannel>().HasKey(x => new { x.UserID, x.ChannelID });

            modelBuilder.Entity<UserChannel>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserChannels)
                .HasForeignKey(uc => uc.UserID);

            modelBuilder.Entity<UserChannel>()
                .HasOne<Channel>(uc => uc.Channel)
                .WithMany(u => u.UserChannels)
                .HasForeignKey(uc => uc.ChannelID);

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserID, x.RoleID });

            modelBuilder.Entity<UserRole>()
                .HasOne<User>(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

        }


    }
}
