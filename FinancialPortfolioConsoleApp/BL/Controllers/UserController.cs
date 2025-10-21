using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp.BL.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }

        public void AddUser()
        {
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            var password = Console.ReadLine();

            if (_userService.AddUser(name, password))
            {
                Console.WriteLine($"Пользователь {name} успешно создан!");
            }
            else
            {
                Console.WriteLine($"Не удалось создать пользователя {name}");
            }
            
        }
    }
}
