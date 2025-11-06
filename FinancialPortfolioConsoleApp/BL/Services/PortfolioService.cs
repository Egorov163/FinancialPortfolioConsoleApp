using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class PortfolioService
    {
        private readonly UserContext _userContext;
        private readonly PortfolioStocksService _portfolioStocksService;
        private readonly PortfolioRepository _portfolioRepository;
        public PortfolioService(
            UserContext userContext,
            StockService stockService,
            PortfolioStocksService portfolioStocksService,
            PortfolioRepository portfolioRepository
            )
        {
            _userContext = userContext;
            _portfolioStocksService = portfolioStocksService;
            _portfolioRepository = portfolioRepository;
        }

        /// <summary>
        /// Добавить портфель.
        /// </summary>
        public void AddPortfolio()
        {
            var currentUser = _userContext.CurrentUser;

            if (currentUser is not null)
            {
                Console.WriteLine("Введите название для портфеля : ");
                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Вы не ввели название");
                }
                else
                {
                    if (!_portfolioRepository.CheckPortfolioByName(currentUser.Id, name))
                    {
                        var portfolio = new PortfolioModel()
                        {
                            Name = name,
                            User = _userContext.CurrentUser,
                        };

                        _portfolioRepository.Add(portfolio);
                    }
                    else
                    {
                        Console.WriteLine($"Портфель {name} уже существует");
                    }
                }
            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }

        /// <summary>
        /// Добавить акцию.
        /// </summary>
        public void AddStocks()
        {
            if (_userContext.CurrentUser != null)
            {
                var portfoliosList = _userContext.CurrentUser.Portfolios;

                Console.WriteLine("В какой портфель вы хотите добавить акции?");

                foreach (var p in portfoliosList)
                {
                    Console.WriteLine(p.Name);
                }

                var portfolioName = Console.ReadLine();

                var portfolio = portfoliosList.FirstOrDefault(p => p.Name == portfolioName);

                if (portfolio is null)
                {
                    Console.WriteLine("Вы не указали портфель");
                }
                else
                {
                    var newPortfolioStock = _portfolioStocksService.AddStock(portfolio);

                    if (newPortfolioStock is not null)
                    {
                        _portfolioRepository.AddInPortfolioStock(portfolio, newPortfolioStock);
                    }
                }

            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }
    }
}
