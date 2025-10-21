using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data
{
    public class AppDbContext : DbContext
    {
        private string _connectionString = "Host=localhost;Port=5432;Database=FinancialPortfolioConsoleAppDB;Username=postgres;Password=admin";
        public DbSet<UserModel> Users => Set<UserModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
