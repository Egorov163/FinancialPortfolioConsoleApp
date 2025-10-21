using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Вы не заполнили имя или пароль");
                return false;
            }
            else
            {
                var user = new UserModel { Name = name, Password = password };
                return _userRepository.AddUser(user);
            }
        }
    }
}
