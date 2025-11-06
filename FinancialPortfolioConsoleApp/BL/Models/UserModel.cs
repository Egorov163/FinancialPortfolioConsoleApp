namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class UserModel : BaseModel
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required UserRoleEnum Role { get; set; }
        public  List<PortfolioModel>? Portfolios { get; set; } = new();
    }
}
