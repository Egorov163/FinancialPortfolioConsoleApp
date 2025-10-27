using FinancialPortfolioConsoleApp.BL.Data.Repositories;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Helpers
{
    public static class Initialization
    {
        public static void AppInit(UserRepository userRepository)
        {
            CreateAdmin(userRepository);
            CreateUser(userRepository);
        }
        private static void CreateAdmin(UserRepository userRepository)
        {
            var adminName = "admin";
            var admin = userRepository.GetByName(adminName);

            if (admin is null)
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(adminName);
                admin = new UserModel() { Name = adminName, Password = hashPassword, Role = UserRole.Admin };
                userRepository.Add(admin);
            }
        }
        private static void CreateUser(UserRepository userRepository)
        {
            var userName = "user";
            var user = userRepository.GetByName(userName);

            if (user is null)
            {
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(userName);
                user = new UserModel() { Name = userName, Password = hashPassword, Role = UserRole.User };
                userRepository.Add(user);
            }
        }
    }
}
