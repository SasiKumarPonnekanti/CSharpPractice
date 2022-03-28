using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cs_JobPortalWebApp.Models
{
    public partial class JobPortalContext : DbContext
    {
        public JobPortalContext()
        {
        }

        public JobPortalContext(DbContextOptions<JobPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CampanyInfo> CampanyInfos { get; set; }
        public virtual DbSet<EduInfo> EduInfos { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<ProjectInfo> ProjectInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=JobPortal;Integrated Security=SSPI");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampanyInfo>(entity =>
            {
                entity.ToTable("CampanyInfo");

                entity.Property(e => e.CampanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Discription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.ResignDate).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CampanyInfos)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__CampanyIn__perso__2C3393D0");
            });

            modelBuilder.Entity<EduInfo>(entity =>
            {
                entity.HasKey(e => e.EduId)
                    .HasName("PK__table_na__1FD9490E4B168B75");

                entity.ToTable("EduInfo");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("date")
                    .HasColumnName("completionDate");

                entity.Property(e => e.EducationType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstituteName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Specification)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Startdate).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EduInfos)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__table_nam__perso__267ABA7A");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Personal__EC7D7D4D14F9F716");

                entity.ToTable("Personal");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlternateContact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("imagePath");

                entity.Property(e => e.ProfilePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("profilePath");
            });

            modelBuilder.Entity<ProjectInfo>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__ProjectI__11F14DA536E79126");

                entity.ToTable("ProjectInfo");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("date")
                    .HasColumnName("completionDate");

                entity.Property(e => e.Discription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ProjectInfos)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__ProjectIn__perso__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
