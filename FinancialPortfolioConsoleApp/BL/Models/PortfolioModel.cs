namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class PortfolioModel : BaseModel
    {
        public required string Name { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public List<PortfolioStocksModel> PortfolioStocks { get; set; } = new();
    }
}
