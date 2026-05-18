using Informatika.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Informatika.Database
{
    public class InformatikaDbContext : DbContext
    {
        public InformatikaDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ConfirmedTask> ConfirmedTasks { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<LectionResource> LectionResources { get; set; }
        public DbSet<LectionTask> LectionTasks { get; set; }
        public DbSet<TaskResource> TaskResources { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserActionLogs)
                .WithOne(al => al.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ConfirmedTasks)
                .WithOne(ct => ct.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lection>()
                .HasMany(l => l.LectionTasks)
                .WithOne(lt => lt.Lection)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Lection>()
                .HasMany(l => l.LectionResources)
                .WithOne(lr => lr.Lection)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LectionTask>()
                .HasMany(lt => lt.TaskResources)
                .WithOne(tr => tr.LectionTask)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LectionTask>()
                .HasMany(lt => lt.ConfirmedTask)
                .WithOne(ct => ct.LectionTask)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ConfirmedTask>()
                .Property(ct => ct.Mark)
                .IsRequired(false);
        }
    }
}
