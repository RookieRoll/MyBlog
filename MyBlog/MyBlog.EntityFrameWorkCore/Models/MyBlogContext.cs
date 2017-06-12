using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class MyBlogContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source =.\sqlexpress; Initial Catalog = MyBlog; User ID = sa; Password = qh18723361304;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ADMIN_REFERENCE_USER");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BLOG_REFERENCE_ADMIN");

                entity.HasOne(d => d.Classify)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.ClassifyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BLOG_REFERENCE_CLASSIFI");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.Property(e => e.ModificationTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.DeletionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_COMMENT_REFERENCE_CUSTOMER");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Comment)
                    .HasForeignKey<Comment>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_COMMENT_REFERENCE_BLOG");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_USER");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreationTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(68);

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }
    }
}