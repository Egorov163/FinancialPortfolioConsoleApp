using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Controllers;
using FinancialPortfolioConsoleApp.BL.Data;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Helpers;
using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp
{
    public class App
    {
        // Контексты.
        private readonly AppDbContext _appDbContext;
        private readonly UserContext _userContext;
        // Репозитории.
        private readonly UserRepository _userRepository;
        private readonly PortfolioRepository _portfolioRepository;
        private readonly PortfolioStocksRepository _portfolioStocksRepository;
        private readonly StockRepository _stockRepository;
        // Сервисы.
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly StockService _stockService;
        private readonly PortfolioService _portfolioService;
        private readonly PortfolioStocksService _portfolioStocksService;
        // Контроллеры.
        private readonly UserController _userController;
        private readonly FinancialController _financialController;
        public App()
        {
            // Контексты.
            _appDbContext = new AppDbContext();
            _userContext = new UserContext();
            // Репозитории.
            _userRepository = new UserRepository(_appDbContext);
            _portfolioRepository = new PortfolioRepository(_appDbContext);
            _portfolioStocksRepository = new PortfolioStocksRepository(_appDbContext);
            _stockRepository = new StockRepository(_appDbContext);
            // Сервисы.
            _authService = new AuthService(_userRepository, _userContext);
            _userService = new UserService(_userRepository, _authService, _userContext);
            _stockService = new StockService(_stockRepository, _portfolioStocksRepository);
            _portfolioStocksService = new PortfolioStocksService(_stockService, _portfolioStocksRepository);
            _portfolioService = new PortfolioService(_userContext, _stockService, _portfolioStocksService, _portfolioRepository  );
            // Контроллеры.
            _userController = new UserController(_userService);
            _financialController = new FinancialController(_portfolioService);


            // Инициализация
            Initialization.AppInit(_userRepository);
        }

        /// <summary>
        /// Запустить приложение.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Вас приветствует приложение Финансовый портфель!");

            while (true)
            {
                Console.WriteLine("С каким модулем вы хотите взаимодействовать?\nВыберите действие: ");

                Console.WriteLine("1 - пользователи");
                Console.WriteLine("2 - финансовый портфель");
                Console.WriteLine("3 - выйти");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.WriteLine();

                    switch (result)
                    {
                        case 1:
                            UsersAction();
                            break;

                        case 2:
                            PortfolioAction();
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Ничего не понял, попробуй ещё раз");
                            break;
                    }
                }
            }
        }

        private void PortfolioAction()
        {
            Console.WriteLine("Модуль: Финансовый портфель");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - добавить акции");
                Console.WriteLine("2 - удалить акции");
                Console.WriteLine("3 - вывести все акции");
                Console.WriteLine("4 - добавить портфель");
                Console.WriteLine("5 - удалить портфель");
                Console.WriteLine("6 - выйти");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.WriteLine();

                    switch (result)
                    {
                        case 1:
                            _financialController.AddStocks();
                            break;

                        case 2:
                            Console.WriteLine("Ещё не готово!");
                            break;

                        case 3:
                            Console.WriteLine("Ещё не готово!");
                            break;

                        case 4:
                            _financialController.AddPortfolio();
                            break;

                        case 5:
                            Console.WriteLine("Ещё не готово!");
                            break;

                        case 6:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Ничего не понял, попробуй ещё раз");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректный ответ");
                }
                Console.WriteLine();
            }
        }

        private void UsersAction()
        {
            Console.WriteLine("Модуль: Пользователи");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - создать пользователя");
                Console.WriteLine("2 - удалить пользователя");
                Console.WriteLine("3 - вывести всех пользователей");
                Console.WriteLine("4 - аутентификация");
                Console.WriteLine("5 - выйти из аккаунта");
                Console.WriteLine("6 - выйти");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.WriteLine();

                    switch (result)
                    {
                        case 1:
                            _userController.AddUser();
                            break;

                        case 2:
                            _userController.RemoveUser();
                            break;

                        case 3:
                            _userController.GetAllUsers();
                            break;

                        case 4:
                            _userController.Login();
                            break;

                        case 5:
                            _userController.Logout();
                            break;

                        case 6:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Ничего не понял, попробуй ещё раз");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректный ответ");
                }
                Console.WriteLine();
            }
        }
    }
}
