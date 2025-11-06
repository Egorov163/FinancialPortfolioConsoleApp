using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data
{
    public class AppDbContext : DbContext
    {
        private string _connectionString = "Host=localhost;Port=5432;Database=FinancialPortfolioConsoleAppDB;Username=postgres;Password=admin";
        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<PortfolioModel> Portfolios => Set<PortfolioModel>();
        public DbSet<StockModel> Stocks => Set<StockModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. User → Portfolio (1 ко многим)
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Portfolios)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 2. Portfolio ↔ PortfolioStock (1 ко многим)
            modelBuilder.Entity<PortfolioModel>()
                .HasMany(p => p.PortfolioStocks)
                .WithOne(ps => ps.Portfolio)
                .HasForeignKey(ps => ps.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. Stock ↔ PortfolioStock(1 ко многим)
            modelBuilder.Entity<StockModel>()
                .HasMany(s => s.PortfolioStocks)
                .WithOne(ps => ps.Stock)
                .HasForeignKey(ps => ps.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            // Композитный ключ
            modelBuilder.Entity<PortfolioStocksModel>()
                .HasKey(ps => new { ps.PortfolioId, ps.StockId });
        }
    }
}
