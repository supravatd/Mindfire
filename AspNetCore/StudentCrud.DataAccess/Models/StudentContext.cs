using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentCrud.DataAccess.Models;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SUPRAVATD-WIN10;Database=student;User Id=sa;Password=mindfire; Trust Server Certificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__address__2A33069ABB1C04C6");

            entity.ToTable("Address");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__address__student__3F466844");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__8F1EF7AE739250A0");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Semester).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__course__semester__4316F928");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__course__teacher___4222D4EF");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId).HasName("PK__ErrorLog__358565CA6EBB43D8");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorId).HasColumnName("ErrorID");
            entity.Property(e => e.LogTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.SemesterId).HasName("PK__semester__CBC81B0186EB948E");

            entity.ToTable("Semester");

            entity.Property(e => e.SemesterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__2A33069A919133E6");

            entity.ToTable("Student");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Semester).WithMany(p => p.Students)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__student__semeste__398D8EEE");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentC__32DD162DF449B7A3");

            entity.ToTable("StudentCourse");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__StudentCo__cours__46E78A0C");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentCo__stude__45F365D3");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__teacher__03AE777EE0997505");

            entity.ToTable("Teacher");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Semester).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__teacher__semeste__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
