using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebServices
{
    public partial class WebservicesContext : DbContext
    {
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<TableOfStatements> TableOfStatements { get; set; }
        public virtual DbSet<TimeTables> TimeTables { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        public WebservicesContext():base()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=WebServices.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TableOfStatements>(entity =>
            {
                entity.HasKey(e => e.AccountNumber);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.TypeOfStatement)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeTables>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LessonName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LessonTeacher)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}