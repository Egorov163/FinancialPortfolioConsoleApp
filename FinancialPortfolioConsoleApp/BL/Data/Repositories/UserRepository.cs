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
    }
}
