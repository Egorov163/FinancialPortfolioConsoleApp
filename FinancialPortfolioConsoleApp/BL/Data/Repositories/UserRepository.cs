using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public bool AddUser(UserModel user)
        {
            if (!_appDbContext.Users.Contains(user))
            {
                _appDbContext.Add(user);
                _appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
