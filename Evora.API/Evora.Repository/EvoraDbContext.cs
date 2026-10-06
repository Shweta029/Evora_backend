//using Evora.Repository.Entity;
//using Microsoft.EntityFrameworkCore;

//namespace Evora.Repository
//{
//    public class EvoraDbContext : DbContext
//    {
//        public EvoraDbContext(DbContextOptions<EvoraDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<User> Users { get; set; }
//        public DbSet<Event> Events { get; set; }
//        public DbSet<Booking> Bookings { get; set; }
//        public DbSet<Payment> Payments { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // User -> Event (1:N)
//            modelBuilder.Entity<Event>()
//                .HasOne(e => e.CreatedByUser)
//                .WithMany()
//                .HasForeignKey(e => e.CreatedBy)
//                .OnDelete(DeleteBehavior.Restrict);

//            // User -> Booking (1:N)
//            modelBuilder.Entity<Booking>()
//                .HasOne(b => b.User)
//                .WithMany()
//                .HasForeignKey(b => b.UserId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Event -> Booking (1:N)
//            modelBuilder.Entity<Booking>()
//                .HasOne(b => b.Event)
//                .WithMany()
//                .HasForeignKey(b => b.EventId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Booking -> Payment (1:1)
//            modelBuilder.Entity<Booking>()
//                .HasOne(b => b.Payment)
//                .WithOne()
//                .HasForeignKey<Booking>(b => b.PaymentId)
//                .OnDelete(DeleteBehavior.SetNull);

//        }
//    }
//}


using Evora.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Evora.Repository;

public class EvoraDbContext : DbContext
{
    public EvoraDbContext(DbContextOptions<EvoraDbContext> options)
        : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("bookings", "Evora");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id");

            entity.Property(x => x.CustomerName)
                .HasColumnName("customerName")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.EventName)
                .HasColumnName("eventName")
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.BookingDate)
                .HasColumnName("bookingDate")
                .IsRequired();

            entity.Property(x => x.Amount)
                .HasColumnName("amount")
                .HasPrecision(10, 2)
                .IsRequired();
        });
    }
}
