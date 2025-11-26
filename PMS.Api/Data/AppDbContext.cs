using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMS.Api.Models.Core;
using PMS.Api.Models.Investments;
using PMS.Api.Models.Liabilities;
using PMS.Api.Models.Savings;

namespace PMS.Api.Data
{
    /// <summary>
    /// Application database context inheriting from IdentityDbContext for authentication.
    /// Configures all entities including TPH pattern for investments.
    /// </summary>
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // === Core Entities ===
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Watch> Watchlist { get; set; }

        // === Investments (TPH Pattern - all stored in single "Investments" table) ===
        public DbSet<Investment> Investments { get; set; }
        public DbSet<StockData> StockData { get; set; }
        public DbSet<MutualFundsData> MutualFundsData { get; set; }
        public DbSet<CryptoData> CryptoData { get; set; }
        public DbSet<RealEstateData> RealEstateData { get; set; }
        public DbSet<GoldData> GoldData { get; set; }
        public DbSet<BondsData> BondsData { get; set; }

        // === Insurance ===
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<InsurancePayment> InsurancePayments { get; set; }

        // === Liabilities ===
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanEmiSchedule> LoanEmiSchedules { get; set; }

        // === Savings ===
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<FixedDeposit> FixedDeposits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // === Configure Table-Per-Hierarchy (TPH) for Investments ===
            // All investment types share a single "Investments" table with discriminator "InvestmentType"
            builder.Entity<Investment>()
                .HasDiscriminator<string>("InvestmentType")
                .HasValue<StockData>("Stock")
                .HasValue<MutualFundsData>("MutualFund")
                .HasValue<CryptoData>("Crypto")
                .HasValue<RealEstateData>("RealEstate")
                .HasValue<GoldData>("Gold")
                .HasValue<BondsData>("Bond");

            // === Portfolio Relationships ===
            builder.Entity<Portfolio>()
                .HasMany(p => p.Investments)
                .WithOne(i => i.Portfolio)
                .HasForeignKey(i => i.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Portfolio>()
                .HasMany(p => p.InsurancePolicies)
                .WithOne(ip => ip.Portfolio)
                .HasForeignKey(ip => ip.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Portfolio>()
                .HasMany(p => p.Loans)
                .WithOne(l => l.Portfolio)
                .HasForeignKey(l => l.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Portfolio>()
                .HasMany(p => p.SavingAccounts)
                .WithOne(sa => sa.Portfolio)
                .HasForeignKey(sa => sa.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Portfolio>()
                .HasMany(p => p.FixedDeposits)
                .WithOne(fd => fd.Portfolio)
                .HasForeignKey(fd => fd.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            // === User Relationships ===
            builder.Entity<User>()
                .HasMany(u => u.Portfolios)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.Watchlist)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Insurance Relationships ===
            builder.Entity<InsurancePolicy>()
                .HasMany(ip => ip.Payments)
                .WithOne(p => p.Policy)
                .HasForeignKey(p => p.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Loan Relationships ===
            builder.Entity<Loan>()
                .HasMany(l => l.EmiSchedules)
                .WithOne(es => es.Loan)
                .HasForeignKey(es => es.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            // === Configure decimal precision for all decimal columns ===
            // This ensures consistent precision across all decimal fields
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        if (property.GetColumnType() == null)
                        {
                            // Default precision for unspecified decimals
                            property.SetColumnType("decimal(18,2)");
                        }
                    }
                }
            }
        }
    }
}
