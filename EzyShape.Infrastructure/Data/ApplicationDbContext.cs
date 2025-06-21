using EzyShape.Infrastructure.Data.Configuration;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportArete.Infrastructure.Data.Configuration;
using System.Reflection.Emit;

namespace EzyShape.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutSplit> WorkoutSplits { get; set; }
        public DbSet<ClientSplit> ClientSplits { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<ExerciseLog> ExerciseLogs { get; set; }
        public DbSet<SetLog> SetLogs { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Split> Splits { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TrainingTask> TrainingTasks { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<TrainerNote> TrainerNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            builder.Entity<User>()
                .HasOne(u => u.Trainer)
                .WithMany(u => u.Clients)
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.NoAction); // or .Restrict

            builder.Entity<User>()
                .HasMany(u => u.SplitIds);

            builder.Entity<User>()
                .Property(u => u.PreferredLanguage)
                .HasDefaultValue("en");




            builder.Entity<ClientSplit>()
                .HasKey(x => new { x.UserId, x.SplitId });

            builder.Entity<WorkoutExercise>().HasKey(we => new { we.WorkoutId, we.ExerciseId });
            builder.Entity<WorkoutSplit>().HasKey(ws => new { ws.SplitId, ws.WorkoutId });



            builder.Entity<Split>()
                .HasMany(u => u.WorkoutIds);

            // WorkoutLog configuration
            builder.Entity<WorkoutLog>()
                .HasMany(wl => wl.ExerciseLogs)
                .WithOne(el => el.WorkoutLog)
                .HasForeignKey(el => el.WorkoutLogId)
                .OnDelete(DeleteBehavior.Cascade); // To Delete ExerciseLogs when a WorkoutLog is deleted

            // ExerciseLog configuration
            builder.Entity<ExerciseLog>()
                .HasMany(el => el.SetLogs)
                .WithOne(sl => sl.ExerciseLog)
                .HasForeignKey(sl => sl.ExerciseLogId)
                .OnDelete(DeleteBehavior.Cascade); // To Delete SetLogs when an ExerciseLog is deleted



            builder.ApplyConfiguration(new RoleConfigration());
            builder.ApplyConfiguration(new EquipmentConfiguration());
            builder.ApplyConfiguration(new LevelConfiguration());
            builder.ApplyConfiguration(new MuscleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}