using FinancialPortfolioConsoleApp.BL.Interfaces;
using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
