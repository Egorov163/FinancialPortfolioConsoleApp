using FinancialPortfolioConsoleApp.BL.Controllers;
using FinancialPortfolioConsoleApp.BL.Data;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp
{
    public class App
    {
        // Контексты.
        private AppDbContext _appDbContext => new AppDbContext();
        // Репозитории.
        private UserRepository _userRepository => new UserRepository(_appDbContext);
        // Сервисы.
        private AuthService _authService => new AuthService(_userRepository);
        private UserService _userService => new UserService(_userRepository, _authService);
        // Контроллеры.
        private UserController _userController => new UserController(_userService);

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
