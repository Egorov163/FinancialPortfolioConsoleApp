using FinancialPortfolioConsoleApp.BL.Services;

namespace FinancialPortfolioConsoleApp.BL.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public void AddUser()
        {
            _userService.AddUser();
        }
        public void RemoveUser()
        {
            _userService.RemoveUser();
        }
        public void GetAllUsers()
        {
            _userService.GetAllUsers();
        }
    }
}
