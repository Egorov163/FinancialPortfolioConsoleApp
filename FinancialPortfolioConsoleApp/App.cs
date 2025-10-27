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
        // Сервисы.
        private readonly AuthService _authService;
        private readonly UserService _userService;
        // Контроллеры.
        private readonly UserController _userController;
        public App()
        {
            _appDbContext = new AppDbContext();
            _userContext = new UserContext();
            _userRepository = new UserRepository(_appDbContext);
            _authService = new AuthService(_userRepository, _userContext);
            _userService = new UserService(_userRepository, _authService, _userContext);
            _userController = new UserController(_userService);

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
                            Environment.Exit(0);
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
