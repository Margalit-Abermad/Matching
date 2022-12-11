using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories.Models
{
    public partial class MatchingContext : DbContext
    {
        public MatchingContext()
        {
        }

        public MatchingContext(DbContextOptions<MatchingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<FundraisingGroup> FundraisingGroups { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Raise> Raises { get; set; } = null!;
        public virtual DbSet<Target> Targets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Name=Matching");
                //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\משתמש זה\\Desktop\\APIProj\\MatchingProj\\DB\\MachingDB.mdf';Integrated Security=True;Connect Timeout=30"/*"Name=Matching"*/);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.DonatesName)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.DonationDate).HasColumnType("datetime");

                entity.HasOne(d => d.FundRaiser)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.FundRaiserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__FundR__52593CB8");

                entity.HasOne(d => d.FundraisingGroup)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.FundraisingGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__Fundr__4E88ABD4");
            });

            modelBuilder.Entity<FundraisingGroup>(entity =>
            {
                entity.ToTable("FundraisingGroup");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.FundraisingGroups)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fundraisi__Targe__2A164134");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionsDetails)
                    .HasMaxLength(200)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PermissionsName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Raise>(entity =>
            {
                entity.ToTable("Raise");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.HasOne(d => d.FundraisingGroup)
                    .WithMany(p => p.Raises)
                    .HasForeignKey(d => d.FundraisingGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Raise__Fundraisi__5165187F");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Raises)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Raise__Permissio__5DCAEF64");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.FundraisingId).HasColumnName("FundraisingID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
