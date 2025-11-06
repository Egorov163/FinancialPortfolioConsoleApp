using FinancialPortfolioConsoleApp.BL.Contexts;
using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly UserContext _userContext;

        public AuthService(UserRepository userRepository, UserContext userContext)
        {
            _userRepository = userRepository;
            _userContext = userContext;
        }
        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        public void Registration()
        {
            Console.WriteLine("Введите имя: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Вы не указали имя");
            }
            else
            {
                var user = _userRepository.GetByName(name);

                if (user is not null)
                {
                    Console.WriteLine($"Пользователь с {name} уже существует");
                }
                else
                {
                    Console.WriteLine("Введите пароль: ");
                    var password = ReadPassword();

                    if (string.IsNullOrWhiteSpace(password))
                    {
                        Console.WriteLine("Вы не указали пароль");
                    }
                    else
                    {
                        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

                        var newUser = new UserModel() 
                        { 
                            Name = name, 
                            Password = hashPassword, 
                            Role = UserRoleEnum.User,
                        };
                        _userRepository.Add(newUser);
                        Console.WriteLine($"Пользователь {newUser.Name} зарегистрирован!");

                        _userContext.CurrentUser = _userRepository.GetByName(name);
                    }
                }
            }
        }

        /// <summary>
        /// Верификация.
        /// </summary>
        /// <returns>true - верификация прошла успешно. false - верификация не прошла.</returns>
        public void Login()
        {
            Console.WriteLine("Введите имя: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Вы не указали имя");
            }
            else
            {
                var user = _userRepository.GetByName(name);

                if (user is null)
                {
                    Console.WriteLine($"Пользователь с именем {name} не найден");
                }
                else
                {
                    Console.WriteLine("Введите пароль: ");
                    var password = ReadPassword();

                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        Console.WriteLine($"Добро пожаловать {user.Name}!");
                        _userContext.CurrentUser = user;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль");
                    }
                }
            }
        }
        /// <summary>
        /// Выйти из аккаунта.
        /// </summary>
        public void Logout()
        {
            if (!_userContext.IsAuthenticated)
            {
                Console.WriteLine("Перед тем как выходить, ты для начала зайди)");
            }
            else
            {
                _userContext.CurrentUser = null;
            }
        }

        /// <summary>
        /// Ввод пароля с отображением * вместо символов.
        /// </summary>
        /// <returns>Пароль</returns>
        private string ReadPassword()
        {
            string pass = "";
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, pass.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }
    }
}
