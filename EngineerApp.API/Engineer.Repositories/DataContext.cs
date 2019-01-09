using Engineer.Models.Models;
using Engineer.Models.Models.Diets;
using Engineer.Models.Models.Survey;
using Engineer.Models.Models.Trainings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engineer.Repositories
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Pupil> Pupils { get; set; }

        // Training
        public DbSet<ExerciseTraining> ExerciseTrainings { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<TrainingDay> TrainingDays { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }

        // Diets
        public DbSet<DietDay> DietDays { get; set; }
        public DbSet<DietDetail> DietDetails { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<DietProduct> DietProducts { get; set; }

        // Survey
        public DbSet<Biceps> Bicepss {get; set;}
        public DbSet<BodyFat> BodyFats { get; set; }
        public DbSet<BodyWeight> BodyWeights { get; set; }
        public DbSet<Calf> Calfs { get; set; }
        public DbSet<Chest> Chests { get; set; }
        public DbSet<Hip> Hips { get; set; }
        public DbSet<Surveyy> Surveys { get; set; }
        public DbSet<Thigh> Thighs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
