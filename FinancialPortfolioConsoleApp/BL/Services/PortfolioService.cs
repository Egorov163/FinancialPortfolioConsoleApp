using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    /// <summary>
    /// Сервис по действиям с портфелем.
    /// </summary>
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

        public void GetAllPortfolio()
        {
            var currentUser = _userContext.CurrentUser;

            if (currentUser is not null)
            {
                var portfolioList = _portfolioRepository.GetPortfoliosByUserId(currentUser.Id);

                if (portfolioList.Any())
                {
                    foreach (var portfolio in portfolioList)
                    {
                        Console.WriteLine(portfolio.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Ещй ни один портфель не добавлен");
                }
            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }

        /// <summary>
        /// Добавить акцию в портфель.
        /// </summary>
        public void AddStockInPortfolio()
        {
            var currentUser = _userContext.CurrentUser;

            if (currentUser is not null)
            {
                var portfoliosList = _portfolioRepository.GetPortfoliosByUserId(currentUser.Id);

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
                    var portfolioStock = _portfolioStocksService.AddPortfolioStock(portfolio);

                    if (portfolioStock is not null)
                    {
                        _portfolioRepository.AddInPortfolioStock(portfolio, portfolioStock);
                    }
                }

            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }

        public void ReadAllStocksFromPortfolio()
        {
            var currentUser = _userContext.CurrentUser;

            if (currentUser is not null)
            {
                var portfoliosList = _portfolioRepository.GetPortfoliosByUserId(currentUser.Id);

                Console.WriteLine("Из какого портфеля вы хотите показать акции?");

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
                    var stocksDto = _portfolioStocksService.GetAllStockModelDtoById(portfolio.Id);

                    foreach (var s in stocksDto)
                    {
                        Console.WriteLine($"Тикер - {s.Ticker} {s.Count}шт. цена {s.Price}р");
                    }
                }
            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }

        public void RemovePortfolio()
        {
            var currentUser = _userContext.CurrentUser;

            if (currentUser is not null)
            {
                var portfoliosList = _portfolioRepository.GetPortfoliosByUserId(currentUser.Id);

                Console.WriteLine("Какой портфель вы хотите удалить?");

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
                    _portfolioRepository.Remove(portfolio.Id);
                }
            }
            else
            {
                Console.WriteLine("Дружище, ты куда спешишь? Для начала зайди под пользователем)");
            }
        }

        public void RemoveStocksFromPortfolio()
        {
            
        }
    }
}
