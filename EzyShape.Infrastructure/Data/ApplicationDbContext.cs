using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportArete.Infrastructure.Data.Configuration;

namespace EzyShape.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Split> Splits { get; set; }
        public DbSet<SplitExercise> SplitExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SplitExercise>()
               .HasKey(x => new { x.SplitId, x.ExerciseId });


            builder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            // Assuming User has a TrainerId which is also a User
            builder.Entity<User>()
                .HasOne(u => u.Trainer)
                .WithMany(u => u.Clients)
                .HasForeignKey(u => u.TrainerId)
                .OnDelete(DeleteBehavior.NoAction); // or .Restrict


            builder.ApplyConfiguration(new RoleConfigration());

            base.OnModelCreating(builder);
        }
    }
}