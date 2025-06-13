using System;
using Microsoft.EntityFrameworkCore;

namespace LiibraryDataAccessLayer.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public  DbSet<Book> Books { get; set; }
        public  DbSet<BookCopy> BookCopies { get; set; }
        public  DbSet<BorrowingRecord> BorrowingRecords { get; set; }
        public  DbSet<Fine> Fines { get; set; }
        public  DbSet<Reservation> Reservations { get; set; }
        public  DbSet<Setting> Settings { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.Property(e => e.BookId).HasColumnName("BookID");
                entity.Property(e => e.Genre).HasMaxLength(50);
                entity.Property(e => e.Isbn).HasMaxLength(50).HasColumnName("ISBN");
                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(e => e.CopyId);
                entity.Property(e => e.CopyId).HasColumnName("CopyID");
                entity.Property(e => e.BookId).HasColumnName("BookID");
                entity.Property(e => e.AvailabilityStatus).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookCopies)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BorrowingRecord>(entity =>
            {
                entity.HasKey(e => e.BorrowingRecordId);
                entity.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
                entity.Property(e => e.CopyId).HasColumnName("CopyID");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.BorrowingDate).HasColumnType("date");
                entity.Property(e => e.DueDate).HasColumnType("date");
                entity.Property(e => e.ActualReturnDate).HasColumnType("date");

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.BorrowingRecords)
                    .HasForeignKey(d => d.CopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BorrowingRecords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.HasKey(e => e.FineId);
                entity.Property(e => e.FineId).HasColumnName("FineID");
                entity.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.FineAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.NumberOfLateDays);
                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.HasOne(d => d.BorrowingRecord)
                    .WithMany(p => p.Fines)
                    .HasForeignKey(d => d.BorrowingRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Fines)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId);
                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
                entity.Property(e => e.CopyId).HasColumnName("CopyID");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.ContactInformation).HasMaxLength(255);
                entity.Property(e => e.LibraryCardNumber).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.SettingsId);
                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.DefaultBorrowDays);
                entity.Property(e => e.DefaultFinePerDay).HasColumnType("decimal(10, 2)");

                entity.HasOne(s => s.User)
                    .WithOne(u => u.settings)
                    .HasForeignKey<Setting>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // البيانات الأولية (Seed Data)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "John Doe",
                    ContactInformation = "john@example.com",
                    LibraryCardNumber = "LC123",
                    Username = "johndoe",
                    PasswordHash = "hashedpassword123"
                });

            modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    SettingsId = 1,
                    UserId = 1,
                    DefaultBorrowDays = 7,
                    DefaultFinePerDay = 4
                });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "C# Programming Basics",
                    Genre = "Programming",
                    Isbn = "978-1234567890"
                });

            modelBuilder.Entity<BookCopy>().HasData(
                new BookCopy
                {
                    CopyId = 1,
                    BookId = 1,
                    AvailabilityStatus = false
                });

            modelBuilder.Entity<BorrowingRecord>().HasData(
                new BorrowingRecord
                {
                    BorrowingRecordId = 1,
                    CopyId = 1,
                    UserId = 1,
                    BorrowingDate = new DateTime(2025, 6, 1),
                    DueDate = new DateTime(2025, 6, 8),
                    ActualReturnDate = null
                });

            modelBuilder.Entity<Fine>().HasData(
                new Fine
                {
                    FineId = 1,
                    BorrowingRecordId = 1,
                    UserId = 1,
                    FineAmount = 0,
                    NumberOfLateDays = 0,
                    PaymentStatus = true
                });

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1,
                    CopyId = 1,
                    UserId = 1
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
