using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMDB_Web_API.Models
{
    public partial class IMDBWEBSITEContext : DbContext
    {
        public IMDBWEBSITEContext()
        {
        }

        public IMDBWEBSITEContext(DbContextOptions<IMDBWEBSITEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<List> Lists { get; set; } = null!;
        public virtual DbSet<MovieList> MovieLists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI ;Database=IMDBWEBSITE;Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("userId");

            });

            modelBuilder.Entity<MovieList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ListId).HasColumnName("listId");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(50)
                    .HasColumnName("movieName");

                entity.Property(e => e.MoviePosterPath)
                    .HasMaxLength(150)
                    .HasColumnName("moviePosterPath");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("userId");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NickName, "UQ__Users__48F06EC154201BEB")
                    .IsUnique();

                entity.HasIndex(e => e.IdentificationNo, "UQ__Users__8E2B5F486FA4CA0E")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E616476DFC90B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.BackgroundImg)
                    .HasMaxLength(150)
                    .HasColumnName("backgroundImg")
                    .HasDefaultValueSql("('../../../assets/images/profileIMGs/timeline.jpg')");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.IdentificationNo)
                    .HasMaxLength(15)
                    .HasColumnName("identificationNo")
                    .IsFixedLength();

                entity.Property(e => e.Img)
                    .HasMaxLength(150)
                    .HasColumnName("img")
                    .HasDefaultValueSql("('../../../assets/images/profileIMGs/defaultProfileImg.jpg'')')");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .HasColumnName("nickName");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
