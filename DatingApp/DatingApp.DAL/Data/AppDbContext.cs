using DatingApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DatingApp.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserHoppy> UserHoppies { get; set; }

        public override int SaveChanges()
        {
            // Lấy toàn bộ entites trong cây
            foreach (var entry in ChangeTracker.Entries()) // Theo dõi toàn bộ thay đổi
            {
                var entity = entry.Entity;

                // KT 1 bản ghi sẽ bị xoá
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;// Cập nhập trạng thái bản ghi đc sửa đổi

                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set PK cho User
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.UserId });

            //Set PK cho Hobby
            modelBuilder.Entity<Hobby>()
                .HasKey(u => new { u.HobbyId });

            //Set PK cho Image
            modelBuilder.Entity<Image>()
                .HasKey(u => new { u.ImageId });

            //Set PK cho Like
            modelBuilder.Entity<Like>()
                .HasKey(u => new { u.LikeId });

            //Set PK cho Message
            modelBuilder.Entity<Message>()
                .HasKey(u => new { u.MessageId });

            //Set PK cho Match
            modelBuilder.Entity<Match>()
                .HasKey(u => new { u.MatchId });

            //Quan hệ 1 - n User vs Image
            modelBuilder.Entity<User>()
                .HasMany(i => i.Images)
                .WithOne(u => u.User);

            //Quan hệ 1 - n User vs Like
            modelBuilder.Entity<User>()
                .HasMany(l => l.Likes)
                .WithOne(u => u.User);

            //Quan hệ n - n User vs Hobby qua bang anh xa UserHobby
            //Tao khoa chinh cho bang userhoppy
            //Tao lk nhieu nhieu
            modelBuilder.Entity<UserHoppy>()
                .HasKey(t => new { t.UserId, t.HobbyId });
            modelBuilder.Entity<UserHoppy>()
                .HasOne(u => u.User)
                .WithMany(uh => uh.UserHoppies)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserHoppy>()
                .HasOne(h => h.Hobby)
                .WithMany(uh => uh.UserHoppies)
                .HasForeignKey(h => h.HobbyId);

        }

    }
}
