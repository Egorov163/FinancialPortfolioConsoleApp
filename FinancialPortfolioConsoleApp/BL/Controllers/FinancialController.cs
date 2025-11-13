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

        /// <summary>
        /// Добавить акцию.
        /// </summary>
        public void AddStocks()
        {
            _portfolioService.AddStockInPortfolio();
        }

        /// <summary>
        /// Добавить портфолио.
        /// </summary>
        public void AddPortfolio()
        {
            _portfolioService.AddPortfolio();
        }

        /// <summary>
        /// Вывести все акции из портфеля.
        /// </summary>
        public void ReadAllStocks()
        {
            _portfolioService.ReadAllStocksFromPortfolio();
        }

        /// <summary>
        /// Удалить акцию из портфеля.
        /// </summary>
        public void RemoveStocksFromPortfolio()
        {
            _portfolioService.RemoveStocksFromPortfolio();
        }

        internal void GetAllPortfolios()
        {
            _portfolioService.GetAllPortfolio();
        }

        internal void RemovePortfolio()
        {
            _portfolioService.RemovePortfolio();
        }

        internal void RemoveStocks()
        {
            throw new NotImplementedException();
        }
    }
}
