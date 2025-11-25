// File: PMS.Api/Data/AppDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMS.Api.Models; // ← This folder we create next

namespace PMS.Api.Data
{
    // Inherits from IdentityDbContext so we get Users, Roles, Login system for free
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // === All tables from your ERD + Nepal extras ===
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentType> InvestmentTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<PerformanceHistory> PerformanceHistories { get; set; }
        public DbSet<DividendBonusHistory> DividendBonusHistories { get; set; }
        public DbSet<TaxRecord> TaxRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // === Relationships from your diagram ===
            builder.Entity<Portfolio>()
                .HasMany(p => p.Investments)
                .WithOne(i => i.Portfolio)
                .HasForeignKey(i => i.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Investment>()
                .HasOne(i => i.InvestmentType)
                .WithMany()
                .HasForeignKey(i => i.InvestmentTypeId);

            // === Seed 11 investment types – Nepal 2025 ready ===
            builder.Entity<InvestmentType>().HasData(
                new InvestmentType { Id = 1, Name = "NEPSE Stock", IsActive = true },
                new InvestmentType { Id = 2, Name = "Mutual Fund", IsActive = true },
                new InvestmentType { Id = 3, Name = "Bonds", IsActive = true },
                new InvestmentType { Id = 4, Name = "Fixed Deposit", IsActive = true },
                new InvestmentType { Id = 5, Name = "Gold", IsActive = true },
                new InvestmentType { Id = 6, Name = "Real Estate", IsActive = true },
                new InvestmentType { Id = 7, Name = "Cryptocurrency", IsActive = false, ComplianceNote = "Banned by NRB – 2025" },
                new InvestmentType { Id = 8, Name = "Provident Funds", IsActive = true },
                new InvestmentType { Id = 9, Name = "Insurance/ULIP", IsActive = true },
                new InvestmentType { Id = 10, Name = "Cooperatives", IsActive = true },
                new InvestmentType { Id = 11, Name = "Other", IsActive = true }
            );
        }
    }
}