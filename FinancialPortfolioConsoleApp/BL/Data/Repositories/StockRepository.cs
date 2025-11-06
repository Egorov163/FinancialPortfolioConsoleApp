using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class StockRepository : BaseRepository<StockModel>
    {
        public StockRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public StockModel? GetByTicker(string ticker)
        {
           return _entities.FirstOrDefault(s => s.Ticker == ticker);
        }
    }
}
