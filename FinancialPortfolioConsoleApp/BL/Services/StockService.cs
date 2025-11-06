using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class StockService
    {
        private readonly StockRepository _stockRepository;
        private readonly PortfolioStocksRepository _portfolioStocksRepository;

        public StockService(StockRepository stockRepository,
            PortfolioStocksRepository portfolioStocksRepository)
        {
            _stockRepository = stockRepository;
            _portfolioStocksRepository = portfolioStocksRepository;
        }

        public StockModel? AddStock(PortfolioModel portfolio)
        {
            Console.WriteLine("Введите тикер акции: ");
            var ticker = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ticker))
            {
                Console.WriteLine("Вы не ввели тикер акции");

                return null;
            }
            else
            {
                var stock = _stockRepository.GetByTicker(ticker);

                if (stock is null)
                {
                    stock = new StockModel()
                    {
                        Ticker = ticker,
                        PortfolioStocks = portfolio.PortfolioStocks
                    };
                    _stockRepository.Add(stock);
                }

                return stock;
            }
        }
    }
}
