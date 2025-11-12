using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class PortfolioRepository : BaseRepository<PortfolioModel>
    {
        public PortfolioRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void AddInPortfolioStock(PortfolioModel portfolio ,PortfolioStocksModel portfolioStock)
        {
            portfolio.PortfolioStocks.Add(portfolioStock);
            _appDbContext.SaveChanges();
        }

        public bool CheckPortfolioByName(int idUser, string namePortfolio)
        {
            return _appDbContext.Portfolios.Any(p => p.Name == namePortfolio && p.User.Id == idUser);
        }

        public List<PortfolioModel> GetPortfoliosByUserId(int id)
        {
            return _appDbContext.Portfolios
                .Where(p => p.UserId == id)
                .Include(p => p.PortfolioStocks)
                .ToList();
        }
    }
}
