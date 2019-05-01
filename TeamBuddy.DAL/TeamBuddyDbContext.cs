using Microsoft.EntityFrameworkCore;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.DAL
{
    public class TeamBuddyDbContext : DbContext
    {
        public TeamBuddyDbContext()
        {
        }

        public TeamBuddyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Post)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired();
            modelBuilder.Entity<Post>()
                .Property(p => p.Text)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(p => p.Text)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(p => p.Posts)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                .Property(p => p.Username)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<Team>()
                .HasMany(p => p.Posts)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Team>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Team>()
                .Property(p => p.Description)
                .IsRequired();

            modelBuilder.Entity<UserTeam>()
                .HasKey(t => new {t.UserId, t.TeamId});
            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.TeamOfUsers)
                .HasForeignKey(ut => ut.UserId);
            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.Team)
                .WithMany(t => t.UserInTeam)
                .HasForeignKey(ut => ut.TeamId);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
