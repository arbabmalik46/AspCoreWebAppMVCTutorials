using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ImageManagement.Model
{
    public partial class ImageManagementContext : DbContext
    {
        public ImageManagementContext()
        {
        }

        public ImageManagementContext(DbContextOptions<ImageManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ImageMetadatum> ImageMetadata { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageMetadatum>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__ImageMet__7516F4EC0D564FF7");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.Tags).HasMaxLength(255);

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UploadedBy).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
