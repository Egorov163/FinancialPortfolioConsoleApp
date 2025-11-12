using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class PortfolioStocksService
    {
        private readonly StockService _stockService;
        private readonly PortfolioStocksRepository _portfolioStocksRepository;

        public PortfolioStocksService(StockService stockService,
            PortfolioStocksRepository portfolioStocksRepository)
        {
            _stockService = stockService;
            _portfolioStocksRepository = portfolioStocksRepository;
        }

        public PortfolioStocksModel? AddPortfolioStock(PortfolioModel portfolio)
        {
            var stock = _stockService.AddStock(portfolio);

            var portfolioStocksList = portfolio.PortfolioStocks;

            if (stock is null)
            {
                return null;
            }
            else
            {
                Console.WriteLine("Введите цену акции.");
                var strPrice = Console.ReadLine();

                if (int.TryParse(strPrice, out int price))
                {
                    Console.WriteLine("Введите количество акций.");

                    var strCount = Console.ReadLine();

                    if (int.TryParse(strCount, out int count))
                    {
                        var portfolioStock = portfolioStocksList.FirstOrDefault(s => Equals(s.Stock, stock));

                        if (portfolioStock is null)
                        {
                            portfolioStock = new PortfolioStocksModel()
                            {
                                Stock = stock,
                                StockId = stock.Id,
                                Portfolio = portfolio,
                                PortfolioId = portfolio.Id,
                                AveragePrice = price,
                                Count = count,
                            };

                            _portfolioStocksRepository.Add(portfolioStock);
                            return null;
                        }
                        else
                        {
                            _portfolioStocksRepository.UpdatePortfolioStock(portfolioStock, price, count);

                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы не ввели количество акций.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Вы не ввели цену.");
                    return null;
                }
            }
        }

        public List<StockModelDto> GetAllStockModelDtoById(int idPortfolio)
        {
            return _portfolioStocksRepository.GetAllStockModelDtoById(idPortfolio);
        }

        public void RemoveStocksFromPortfolio()
        {

        }
    }
}
