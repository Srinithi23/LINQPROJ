using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LINQPROJ.Models
{
    public partial class DEMODBContext : DbContext
    {
        public DEMODBContext()
        {
        }

        public DEMODBContext(DbContextOptions<DEMODBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empdetail> Empdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-335;Database\n=DEMODB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Empdetail>(entity =>
            {
                entity.ToTable("Empdetail");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
