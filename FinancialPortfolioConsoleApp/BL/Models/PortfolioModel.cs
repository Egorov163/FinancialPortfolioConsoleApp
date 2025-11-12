namespace FinancialPortfolioConsoleApp.BL.Models
{
    /// <summary>
    /// Модель портфеля.
    /// </summary>
    public class PortfolioModel : BaseModel
    {
        public required string Name { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public List<PortfolioStocksModel> PortfolioStocks { get; set; } = new();
    }
}
