using FinancialPortfolioConsoleApp.BL.Interfaces;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        /// <summary>
        /// Получить пользователя по имени.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Пользователь</returns>
        public UserModel? GetByName(string name)
        {
            return _entities.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Проверить, есть ли пользователь с таким именем.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <returns>true - есть / false - нет</returns>
        public bool CheckByName(string name)
        {
            return _entities.Any(x => x.Name == name);
        }
    }
}
