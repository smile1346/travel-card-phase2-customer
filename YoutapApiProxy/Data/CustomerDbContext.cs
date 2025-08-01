using Microsoft.EntityFrameworkCore;
using CustomerService.Models;

namespace CustomerService.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MBankingCustomer> MBankingCustomers { get; set; }
        public DbSet<NonMBankingCustomer> NonMBankingCustomers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CustomerPreference> CustomerPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer configuration
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CustomerId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CustomerName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.MobileNo).HasMaxLength(20);
                
                entity.HasIndex(e => e.CustomerId).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                
                entity.HasOne(e => e.MBankingProfile)
                    .WithOne(m => m.Customer)
                    .HasForeignKey<MBankingCustomer>(m => m.CustomerId);
                
                entity.HasOne(e => e.NonMBankingProfile)
                    .WithOne(n => n.Customer)
                    .HasForeignKey<NonMBankingCustomer>(n => n.CustomerId);
                
                entity.HasMany(e => e.Cards)
                    .WithOne(c => c.Customer)
                    .HasForeignKey(c => c.CustomerId);
                
                entity.HasMany(e => e.Preferences)
                    .WithOne(p => p.Customer)
                    .HasForeignKey(p => p.CustomerId);
            });

            // MBankingCustomer configuration
            modelBuilder.Entity<MBankingCustomer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BANNo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BranchCode).HasMaxLength(20);
                entity.Property(e => e.AccountType).HasMaxLength(50);
                entity.Property(e => e.AccountBalance).HasPrecision(18, 2);
                
                entity.HasIndex(e => e.BANNo).IsUnique();
            });

            // NonMBankingCustomer configuration
            modelBuilder.Entity<NonMBankingCustomer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdentificationType).HasMaxLength(50);
                entity.Property(e => e.IdentificationNumber).HasMaxLength(100);
                entity.Property(e => e.Nationality).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
            });

            // Card configuration
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CardNo).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CardType).HasMaxLength(50);
                entity.Property(e => e.CardBrand).HasMaxLength(50);
                entity.Property(e => e.MaskedCardNumber).HasMaxLength(20);
                entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
                entity.Property(e => e.AvailableBalance).HasPrecision(18, 2);
                entity.Property(e => e.Currency).HasMaxLength(3);
                
                entity.HasIndex(e => e.CardNo).IsUnique();
            });

            // CustomerPreference configuration
            modelBuilder.Entity<CustomerPreference>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PreferenceKey).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PreferenceValue).HasMaxLength(1000);
                
                entity.HasIndex(e => new { e.CustomerId, e.PreferenceKey }).IsUnique();
            });
        }
    }
}