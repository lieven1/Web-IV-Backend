using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web4Api.Models;

namespace Web4Api.Data
{
    public class DbContext : IdentityDbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Forum> Fora { get; set; }
        public DbSet<ForumLid> Forumleden { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Gebruiker>().HasKey(u => u.Id);
            builder.Entity<Gebruiker>().Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Entity<Gebruiker>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Gebruiker>().Property(u => u.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Gebruiker>().Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Entity<Forum>().HasKey(f => f.Id);
            builder.Entity<Forum>().Property(f => f.Naam).IsRequired().HasMaxLength(50);

            builder.Entity<ForumLid>().HasKey(fl => new { fl.ForumId, fl.GebruikerId });
            builder.Entity<ForumLid>().HasOne(fl => fl.Forum)
                .WithMany(f => f.ForaLidschappen)
                .HasForeignKey(fl => fl.ForumId);
            builder.Entity<ForumLid>().HasOne(fl => fl.Gebruiker)
                .WithMany(g => g.ForaLidschappen)
                .HasForeignKey(fl => fl.GebruikerId);

            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Inhoud).IsRequired().HasMaxLength(200);
            builder.Entity<Post>().Property(p => p.likes).IsRequired().HasDefaultValue(0);
            builder.Entity<Post>().Property(p => p.dislikes).IsRequired().HasDefaultValue(0);
            builder.Entity<Post>().HasOne(p => p.Forum).WithMany(f => f.Posts);
        }
    }
}