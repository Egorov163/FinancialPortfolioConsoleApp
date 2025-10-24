using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Contexts
{
    public class UserContext
    {
        public UserModel? CurrentUser { get; set; }
        public bool IsAuthenticated => CurrentUser != null;
    }
}
