<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;
using Online_Learning_App.Infrastructure.Services;
using System;

namespace Online_Learning_App.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; } // **Newly Added**
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGrade> SubjectGrade { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<FinalGrade> FinalGrade { get; set; }

        public DbSet<ActivityGrade> ActivityGrade { get; set; }
        


        public DbSet<ClassGroupSubjectGrade> ClassGroupSubjectGrade { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<ClassGroupSubject> ClassGroupSubjectsInformation
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rename Identity Tables
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            // Map Entities to Tables
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<ClassGroup>().ToTable("ClassGroups");
            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<Submission>().ToTable("Submissions");

            // Define the relationships

            // **Allow NULL for ClassGroupId in Activity**
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.ClassGroup)
                .WithMany(cg => cg.Activities)
                .HasForeignKey(a => a.ClassGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            //// **ClassGroup - Teacher Relationship**
            //modelBuilder.Entity<ClassGroup>()
            //    .HasOne(cg => cg.Teacher)
            //    .WithMany(t => t.ClassGroups)
            //    .HasForeignKey(cg => cg.TeacherId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // Admin → User
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Admin → Role
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // **ClassGroup - Admin Relationship**
            modelBuilder.Entity<ClassGroup>()
                .HasOne(cg => cg.Admin)
                .WithMany(t => t.ClassGroups)
                .HasForeignKey(cg => cg.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            // **Student - ClassGroup Relationship (Allow NULL)**
            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassGroup)
                .WithMany(cg => cg.Students)
                .HasForeignKey(s => s.ClassGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            // **Student - Role Relationship**
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Role)
                .WithMany()
                .HasForeignKey(s => s.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Submission>()
        .HasOne(s => s.Student) // Define the foreign key relationship
        .WithMany(s => s.Submissions)
        .HasForeignKey(s => s.StudentId)
        .OnDelete(DeleteBehavior.Restrict);
            // **Teacher - Role Relationship**
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Role)
                .WithMany()
                .HasForeignKey(t => t.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Student>()
            //  .HasOne(s => s.User)
            //  .WithOne() // One-to-one relationship
            //  .HasForeignKey<Student>(s => s.UserId)
            //  .OnDelete(DeleteBehavior.Cascade);
            // Student - User Relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust as needed

            // Teacher - User Relationship
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne() // One-to-one relationship
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationUser - Teacher Relationship (Explicit Configuration)

            modelBuilder.Entity<Activity>()
      .HasOne(a => a.Subject)
      .WithMany()
      .HasForeignKey(a => a.SubjectId)
      .OnDelete(DeleteBehavior.Cascade); // Ensure cascade delete is enabled
            
            modelBuilder.Entity<ClassGroupSubjectGrade>()
           .HasKey(csg => new { csg.ClassGroupId, csg.SubjectId, csg.GradeId });
            modelBuilder.Entity<Grade>()
        .Property(g => g.MaxMarks)
        .HasPrecision(10, 2);


            modelBuilder.Entity<ClassGroupSubjectGrade>()
          .Property(c => c.ObtainedMarks)
          .HasColumnType("decimal(18,2)"); // Precision of 18 digits and 2 decimals

            modelBuilder.Entity<Grade>()
                .Property(g => g.MinMarks)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SubjectGrade>()
                .Property(sg => sg.MaxMarks)
                .HasColumnType("decimal(18,2)");

        }

=======
﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Learning_App.Domain.Entities;

namespace Online_Learning_App.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
>>>>>>> a0811f2 (Add project files.)
    }
}
