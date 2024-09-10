using Microsoft.EntityFrameworkCore;
using MyWorkoutAppApi.Models;

namespace MyWorkoutAppApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutLog>()
                .HasOne(wl => wl.User)
                .WithMany(u => u.WorkoutLogs)
                .HasForeignKey(wl => wl.UserId);

            modelBuilder.Entity<WorkoutLog>()
                .HasOne(wl => wl.Workouts)
                .WithMany(w => w.WorkoutLogs)
                .HasForeignKey(wl => wl.WorkoutId);
        }
    }
}
