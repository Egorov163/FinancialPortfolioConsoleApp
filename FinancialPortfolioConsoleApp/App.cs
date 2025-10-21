using FinancialPortfolioConsoleApp.BL.Controllers;
using FinancialPortfolioConsoleApp.BL.Data;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp
{
    public class App
    {
        private AppDbContext _appDbContext => new AppDbContext();
        private UserRepository _userRepository => new UserRepository(_appDbContext);
        private UserService _userService => new UserService(_userRepository);
        private UserController _userController => new UserController(_userService);

        public void Start()
        {
            Console.WriteLine("Вас приветствует приложение Финансовый портфель!");

            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - создать пользователя");
                Console.WriteLine("2 - выйти");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            _userController.AddUser();
                            break;

                        case 2:
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
            }
        }
    }
}
