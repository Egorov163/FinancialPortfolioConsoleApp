using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Controllers;
using FinancialPortfolioConsoleApp.BL.Data;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp
{
    public class App
    {
        // Контексты.
        private AppDbContext _appDbContext;
        private UserContext _userContext;
        // Репозитории.
        private UserRepository _userRepository;
        // Сервисы.
        private AuthService _authService;
        private UserService _userService;
        // Контроллеры.
        private UserController _userController;
        public App()
        {
            _appDbContext = new AppDbContext();
            _userContext = new UserContext();
            _userRepository = new UserRepository(_appDbContext);
            _authService = new AuthService(_userRepository, _userContext);
            _userService = new UserService(_userRepository, _authService, _userContext);
            _userController = new UserController(_userService);
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
