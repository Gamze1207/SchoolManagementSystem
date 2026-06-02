using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.SqlRepositories
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {

        }

        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(
           "Server=(localdb)\\MSSQLLocalDB;Database=SchoolDb;Integrated Security=True;");


        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSchedule> TeacherSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Name);
                entity.Property(t => t.subjects);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(c => c.Name);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(s => s.Type);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property<int>("Id");
                entity.HasKey("Id");

                entity.HasOne(s => s.Class)
                      .WithMany(c => c.students)
                      .HasForeignKey("ClassName");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property<int>("Id");
                entity.HasKey("Id");

                entity.HasOne(g => g.Student)
                      .WithMany(s => s.grades)
                      .HasForeignKey("StudentId");

                entity.HasOne(g => g.Subject)
                      .WithMany()
                      .HasForeignKey("SubjectType");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property<int>("Id");
                entity.HasKey("Id");

                entity.HasOne(a => a.Student)
                      .WithMany(s => s.attendances)
                      .HasForeignKey("StudentId");
            });

            modelBuilder.Entity<TeacherSchedule>(entity =>
            {
                entity.Property<int>("Id");
                entity.HasKey("Id");

                entity.HasOne(ts => ts.Teacher)
                      .WithMany(t => t.schedules)
                      .HasForeignKey("TeacherName");

                entity.HasOne(ts => ts.Class)
                      .WithMany(c => c.schedules)
                      .HasForeignKey("ClassName");

                entity.Property(ts => ts.Subject);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property<int>("Id");
                entity.HasKey("Id");

                entity.HasOne(s => s.Schedules)
                      .WithOne()
                      .HasForeignKey<Schedule>("TeacherScheduleId");

                entity.OwnsOne(s => s.Slot, b =>
                {
                    b.Property(slot => slot.Day).HasColumnName("SlotDay");
                    b.Property(slot => slot.Period).HasColumnName("SlotPeriod");
                });
            });
        }
    }
}
