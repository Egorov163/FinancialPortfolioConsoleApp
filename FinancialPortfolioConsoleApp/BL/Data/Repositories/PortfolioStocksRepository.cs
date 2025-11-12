using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class PortfolioStocksRepository : BaseRepository<PortfolioStocksModel>
    {
        public PortfolioStocksRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void UpdatePortfolioStock(PortfolioStocksModel portfolioStock, int price, int count)
        {
            portfolioStock.AveragePrice += price;
            portfolioStock.Count += count;
            _appDbContext.SaveChanges();
        }

        public List<StockModelDto> GetAllStockModelDtoById(int portfolioId)
        {
            return _entities.Include(s => s.Stock)
                .Where(s => s.PortfolioId == portfolioId)
                .Select(s => new StockModelDto
                {
                    Count = s.Count,
                    Price = s.AveragePrice,
                    Ticker = s.Stock.Ticker
                })
                .ToList();
        }
    }
}
