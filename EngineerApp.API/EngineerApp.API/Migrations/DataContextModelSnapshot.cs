﻿// <auto-generated />
using System;
using Engineer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EngineerApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DietPlanId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DietPlanId");

                    b.ToTable("DietDays");
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<int>("DietDayId");

                    b.Property<string>("Dish");

                    b.Property<DateTime>("Hour");

                    b.Property<string>("Meal");

                    b.Property<string>("Recipe");

                    b.HasKey("Id");

                    b.HasIndex("DietDayId");

                    b.ToTable("DietDetails");
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Name");

                    b.Property<int?>("TrainerDietId");

                    b.Property<int?>("UserDietId");

                    b.HasKey("Id");

                    b.HasIndex("TrainerDietId");

                    b.HasIndex("UserDietId");

                    b.ToTable("DietPlans");
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DietDetailId");

                    b.Property<string>("HomeMeasure");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("DietDetailId");

                    b.ToTable("DietProducts");
                });

            modelBuilder.Entity("Engineer.Models.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Engineer.Models.Models.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PupilId");

                    b.Property<int?>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("PupilId")
                        .IsUnique()
                        .HasFilter("[PupilId] IS NOT NULL");

                    b.HasIndex("TrainerId");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("Engineer.Models.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.ExerciseTraining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("TrainingDayId");

                    b.HasKey("Id");

                    b.HasIndex("TrainingDayId");

                    b.ToTable("ExerciseTrainings");
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseTrainingId");

                    b.Property<int>("Number");

                    b.Property<int>("SerialNumber");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTrainingId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.TrainingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day");

                    b.Property<int>("TrainingPlanId");

                    b.Property<string>("TypeOfTraining");

                    b.HasKey("Id");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("TrainingDays");
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Name");

                    b.Property<int?>("TrainerId");

                    b.Property<string>("TrainerName");

                    b.Property<int?>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.HasIndex("UserId");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Engineer.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Gender");

                    b.Property<string>("Interests");

                    b.Property<string>("Introduction");

                    b.Property<string>("KnownAs");

                    b.Property<DateTime>("LastActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("LookingFor");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Engineer.Models.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietDay", b =>
                {
                    b.HasOne("Engineer.Models.Models.Diets.DietPlan", "DietPlan")
                        .WithMany("DietDays")
                        .HasForeignKey("DietPlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietDetail", b =>
                {
                    b.HasOne("Engineer.Models.Models.Diets.DietDay", "DietDay")
                        .WithMany("DietDetails")
                        .HasForeignKey("DietDayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietPlan", b =>
                {
                    b.HasOne("Engineer.Models.Models.User", "TrainerDiet")
                        .WithMany("TrainersDiet")
                        .HasForeignKey("TrainerDietId");

                    b.HasOne("Engineer.Models.Models.User", "UserDiet")
                        .WithMany("UsersDiet")
                        .HasForeignKey("UserDietId");
                });

            modelBuilder.Entity("Engineer.Models.Models.Diets.DietProduct", b =>
                {
                    b.HasOne("Engineer.Models.Models.Diets.DietDetail", "DietDetail")
                        .WithMany("DietProducts")
                        .HasForeignKey("DietDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Photo", b =>
                {
                    b.HasOne("Engineer.Models.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Pupil", b =>
                {
                    b.HasOne("Engineer.Models.Models.User", "PupilTrainer")
                        .WithOne("PupilsTrainer")
                        .HasForeignKey("Engineer.Models.Models.Pupil", "PupilId");

                    b.HasOne("Engineer.Models.Models.User", "TrainerPupil")
                        .WithMany("TrainersPupil")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.ExerciseTraining", b =>
                {
                    b.HasOne("Engineer.Models.Models.Trainings.TrainingDay", "TrainingDay")
                        .WithMany("ExerciseTrainings")
                        .HasForeignKey("TrainingDayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.Serie", b =>
                {
                    b.HasOne("Engineer.Models.Models.Trainings.ExerciseTraining", "ExerciseTraining")
                        .WithMany("Series")
                        .HasForeignKey("ExerciseTrainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.TrainingDay", b =>
                {
                    b.HasOne("Engineer.Models.Models.Trainings.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingDays")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Engineer.Models.Models.Trainings.TrainingPlan", b =>
                {
                    b.HasOne("Engineer.Models.Models.User", "TrainerPlan")
                        .WithMany("Trainers")
                        .HasForeignKey("TrainerId");

                    b.HasOne("Engineer.Models.Models.User", "UserPlan")
                        .WithMany("Users")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Engineer.Models.Models.UserRole", b =>
                {
                    b.HasOne("Engineer.Models.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Engineer.Models.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Engineer.Models.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Engineer.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Engineer.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Engineer.Models.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
