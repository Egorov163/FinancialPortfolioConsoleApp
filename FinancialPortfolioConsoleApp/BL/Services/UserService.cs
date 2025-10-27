using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AuthService _authService;
        private readonly UserContext _userContext;

        public UserService(UserRepository userRepository, AuthService authService, UserContext userContext)
        {
            _userRepository = userRepository;
            _authService = authService;
            _userContext = userContext;
        }
        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        public void AddUser()
        {
            _authService.Registration();
        }
        /// <summary>
        /// Войти в аккаунт.
        /// </summary>
        public void Login()
        {
            _authService.Login();
        }
        /// <summary>
        /// Выйти из аккаунта.
        /// </summary>
        public void Logout()
        {
            _authService.Logout();
        }
        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        public void RemoveUser()
        {
            if (_userContext.CurrentUser?.Role == UserRole.Admin)
            {
                Console.WriteLine("Введите id пользователя, которого хотите удалить: ");
                var idStr = Console.ReadLine();

                if (int.TryParse(idStr, out int id))
                {
                    if (_userRepository.Remove(id))
                    {
                        Console.WriteLine("Пользователь удалён.");
                    }
                    else
                    {
                        Console.WriteLine("Пользователя удалить не удалось, что-то пошло не так.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы не можете удалять пользователей, у вас нет прав.");
            }
        }
        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
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
