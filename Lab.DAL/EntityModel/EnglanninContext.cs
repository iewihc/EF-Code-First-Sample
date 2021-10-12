using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab.DAL.EntityModel
{
    public class EnglanninContext : DbContext
    {
        private static readonly bool[] s_migrated = { false };

        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<ClassRoom> ClassRoom { get; set; }
        public virtual DbSet<TeacherClassRoom> TeacherClassRoom { get; set; }


        public EnglanninContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<School>()
                .HasMany(c => c.Teachers)
                .WithOne(e => e.School);
        }
        
        public EnglanninContext(DbContextOptions<EnglanninContext> options)
            : base(options)
        {
            if (options == null)
            {
                options = DbOptionsFactory.DbContextOptions;
            }

            if (!s_migrated[0])
            {
                lock (s_migrated)
                {
                    if (!s_migrated[0])
                    {
                        this.Database.Migrate();
                        s_migrated[0] = true;
                    }
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "Server=(localdb)\\mssqllocaldb;Database=LabEmployee.DAL;Trusted_Connection=True;";
            var connectionString = DbOptionsFactory.ConnectionString;
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseSqlServer(connectionString);
            }
        }
    }

    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
　　
        public ICollection<Teacher> Teachers { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeskID { get; set; }
　　
        public Desk Desk { get; set; }
    }

    public class Desk
    {
        public int Id { get; set; }
        public string Name { get; set; }
　　
        public Student Student { get; set; }
    }
}