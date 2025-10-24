namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class UserModel : BaseModel
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required UserRole Role { get; set; }
    }
}
