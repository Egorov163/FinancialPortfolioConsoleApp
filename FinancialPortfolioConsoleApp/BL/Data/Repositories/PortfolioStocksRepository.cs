using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class PortfolioStocksRepository : BaseRepository<PortfolioStocksModel>
    {
        public PortfolioStocksRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void UpdatePortfolioStock(PortfolioStocksModel portfolioStock, int price, int count)
        {
            portfolioStock.AveragePrice = price;
            portfolioStock.Count += count;
            _appDbContext.SaveChanges();
        }
    }
}
