using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Data
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookTransfer> BookTransfers { get; set; } = null!;
        public virtual DbSet<Reader> Readers { get; set; } = null!;
        public virtual DbSet<TransferType> TransferTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=library;uid=root;pwd=Password123!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(45)
                    .HasColumnName("author");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<BookTransfer>(entity =>
            {
                entity.ToTable("book_transfer");

                entity.HasIndex(e => e.BookId, "fk_book");

                entity.HasIndex(e => e.ReaderId, "fk_reader");

                entity.HasIndex(e => e.TransferTypeId, "fk_transfer_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.ReaderId).HasColumnName("reader_id");

                entity.Property(e => e.TransferTypeId).HasColumnName("transfer_type_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookTransfers)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("fk_book");

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.BookTransfers)
                    .HasForeignKey(d => d.ReaderId)
                    .HasConstraintName("fk_reader");

                entity.HasOne(d => d.TransferType)
                    .WithMany(p => p.BookTransfers)
                    .HasForeignKey(d => d.TransferTypeId)
                    .HasConstraintName("fk_transfer_type");
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("reader");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<TransferType>(entity =>
            {
                entity.ToTable("transfer_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
