using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkApp.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
    }

    public class MyDBContext : DbContext
    {
        public DbSet<StudentModels> Students { get; set; }
        public DbSet<LectionModels> Lections { get; set; }
        public DbSet<AttendanceModels> Attendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModels>().HasKey(p => p.Id);
            modelBuilder.Entity<StudentModels>().Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<LectionModels>().HasKey(b => b.Id);
            modelBuilder.Entity<LectionModels>().Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AttendanceModels>().HasKey(b => b.Id);
            modelBuilder.Entity<AttendanceModels>().Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AttendanceModels>().HasRequired(p => p.lectionModels)
                .WithMany(b => b.attendanceModels).HasForeignKey(b => b.IdLection);

            base.OnModelCreating(modelBuilder);
        }  
    }
}