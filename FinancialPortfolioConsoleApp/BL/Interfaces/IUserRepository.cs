using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Interfaces
{
    public interface IUserRepository
    {
        UserModel? GetByName(string name);
    }
}