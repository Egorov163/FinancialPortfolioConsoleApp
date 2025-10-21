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

        public void AddUser()
        {
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            var password = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Вы не заполнили имя или пароль");
            }
            else
            {
                var user = new UserModel { Name = name, Password = password };
                _userRepository.Add(user);
                Console.WriteLine($"Пользователь {name} успешно создан!");
            }
        }
        public void RemoveUser()
        {
            Console.WriteLine("Введите id пользователя, которого хотите удалить: ");
            var idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int id))
            {
                _userRepository.Remove(id);
            }
        }
        public void GetAllUsers()
        {
            var usersList = _userRepository.GetAll();

            if (usersList.Any())
            {
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
