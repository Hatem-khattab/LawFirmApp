using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LawFirmApp.Entities;

public partial class LawAndCasesContext : DbContext
{
    public LawAndCasesContext()
    {
    }

    public LawAndCasesContext(DbContextOptions<LawAndCasesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<CasesWithLawyer> CasesWithLawyers { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Lawyer> Lawyers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GWTC71427;Database=LawAndCases;Trusted_Connection=True;TrustServerCertificate=True; User Id=sa;password=12345;Integrated Security=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Case>(entity =>
        {
            entity.ToTable("Case");

            entity.Property(e => e.CaseInformaion).HasMaxLength(50);
            entity.Property(e => e.CaseName).HasMaxLength(50);

            entity.HasOne(d => d.CaseLawyerNavigation).WithMany(p => p.Cases)
                .HasForeignKey(d => d.CaseLawyer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Case_Lawyer");
        });

        modelBuilder.Entity<CasesWithLawyer>(entity =>
        {
            entity.HasKey(e => new { e.CaseId, e.LawyerId });

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.ToTable("File");

            entity.Property(e => e.ContentType).HasMaxLength(100);
            entity.Property(e => e.FileName).HasMaxLength(255);
        });

        modelBuilder.Entity<Lawyer>(entity =>
        {
            entity.ToTable("Lawyer");

            entity.Property(e => e.LawyerLocation).HasMaxLength(50);
            entity.Property(e => e.LawyerName).HasMaxLength(50);
            entity.Property(e => e.LawyerPhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Lawyerpicture)
                .HasMaxLength(50)
                .HasColumnName("lawyerpicture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
