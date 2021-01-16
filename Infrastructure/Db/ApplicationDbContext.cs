using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<classesModel> Classes { get; set; }
        public DbSet<HomeWorksModel> HomeWorks { get; set; }
        public DbSet<MeetingsModel> Meetings { get; set; }
        public DbSet<ObjectsModel> Objects { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<TeachersModel> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set the PKs
            modelBuilder.Entity<classesModel>()
                .HasKey(a => new {a.Id, a.ClassNo});
            modelBuilder.Entity<classesModel>()
                .HasIndex(a => a.ClassNo)
                .IsUnique();
            modelBuilder.Entity<StudentsModel>()
                .HasKey(a => new {a.Id, a.Ssn});
            modelBuilder.Entity<StudentsModel>()
                .HasIndex(a => a.Ssn)
                .IsUnique();
            modelBuilder.Entity<TeachersModel>()
                .HasKey(a => new {a.Id, a.Ssn});
            modelBuilder.Entity<TeachersModel>()
                .HasIndex(a => a.Ssn)
                .IsUnique();

            //Set relationships 
            modelBuilder.Entity<MeetingsModel>()
                .HasOne(s => s.Teacher)
                .WithMany(s => s.Meetings)
                .HasForeignKey(s => new {s.TeacherId})
                .HasPrincipalKey(s => new {s.Id});

            modelBuilder.Entity<MeetingsModel>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Meetings)
                .HasForeignKey(s => new {s.ClassNo})
                .HasPrincipalKey(s => new {s.ClassNo});

            modelBuilder.Entity<ObjectsModel>()
                .HasOne(s => s.Teacher)
                .WithMany(s => s.Objects)
                .HasForeignKey(s => new {s.TeacherId})
                .HasPrincipalKey(s => new {s.Id});

            modelBuilder.Entity<ObjectsModel>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Objects)
                .HasForeignKey(s => s.ClassNo)
                .HasPrincipalKey(s => s.ClassNo);

            modelBuilder.Entity<HomeWorksModel>()
                .HasOne(s => s.Class)
                .WithMany(s => s.HomeWorks)
                .HasForeignKey(s => s.ClassNo)
                .HasPrincipalKey(s => s.ClassNo);

            modelBuilder.Entity<HomeWorksModel>()
                .HasOne(s => s.Teacher)
                .WithMany(s => s.HomeWorks)
                .HasForeignKey(s => s.TeacherId)
                .HasPrincipalKey(s => s.Id);
            modelBuilder.Entity<HomeWorksModel>()
                .HasOne(s => s.Object)
                .WithMany(s => s.HomeWorks)
                .HasForeignKey(s => s.ObjectId)
                .HasPrincipalKey(s => s.Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<StudentsModel>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.ClassNo)
                .HasPrincipalKey(s => s.ClassNo);
        }
    }
}