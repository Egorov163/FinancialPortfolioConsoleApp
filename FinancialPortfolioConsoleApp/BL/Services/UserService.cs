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
            Init();
        }
        /// <summary>
        /// Получить текущего пользователя.
        /// </summary>
        /// <returns>Текущий пользователь.</returns>
        public UserModel? GetCurrentUser()
        {
            return _authService.CurrentUser;
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
            Console.WriteLine("Введите id пользователя, которого хотите удалить: ");
            var idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id))
            {
                _userRepository.Remove(id);
                Console.WriteLine();
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
        /// <summary>
        /// Создать необходимых пользователей.
        /// </summary>
        private void Init()
        {
            CreateAdmin();
        }
        /// <summary>
        /// Создать админа.
        /// </summary>
        private void CreateAdmin()
        {
            var adminName = "admin";
            var admin = _userRepository.GetByName(adminName);

            if (admin is null)
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(adminName);
                admin = new UserModel() { Name = adminName, Password = hashPassword };
                _userRepository.Add(admin);
            }
        }
    }
}
