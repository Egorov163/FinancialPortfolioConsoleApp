using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AuthService _authService;

        public UserService(UserRepository userRepository, AuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public UserModel? GetCurrentUser()
        {
            return _authService.CurrentUser;
        }
        public void AddUser()
        {
            _authService.Registration();
        }
        public void Login()
        {
            _authService.Login();
        }
        public void Logout()
        {
            _authService.Logout();
        }
        public void RemoveUser()
        {
            Console.WriteLine("Введите id пользователя, которого хотите удалить: ");
            var idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id))
            {
                _userRepository.Remove(id);
                Console.WriteLine();
            }
        }
        public void GetAllUsers()
        {
            var usersList = _userRepository.GetAll();

            if (usersList.Any())
            {
                Console.WriteLine("\nНа данный момент зарегистрированы следующие пользователи: ");
                foreach (var user in usersList)
                {
                    Console.WriteLine($"Имя - {user.Name} Id - {user.Id}");
                }
            }
            else
            {
                Console.WriteLine("Пользователи не найдены");
            }
        }
    }
}
