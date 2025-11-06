namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class StockModel : BaseModel
    {
        public required string Ticker { get; set; }
        public List<PortfolioStocksModel> PortfolioStocks { get; set; } = new();
    }
}