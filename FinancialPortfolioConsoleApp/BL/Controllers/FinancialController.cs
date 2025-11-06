using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp.BL.Controllers
{
    public class FinancialController
    {
        private readonly PortfolioService _portfolioService;
        public FinancialController(PortfolioService portfolioService) 
        {
            _portfolioService = portfolioService;
        }

        public void AddStocks()
        {
            _portfolioService.AddStocks();
        }

        public void AddPortfolio()
        {
            _portfolioService.AddPortfolio();
        }
    }
}
