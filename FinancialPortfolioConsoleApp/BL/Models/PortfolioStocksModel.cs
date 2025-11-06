namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class PortfolioStocksModel : BaseModel
    {
        public int PortfolioId { get; set; }
        public PortfolioModel Portfolio { get; set; }

        public int StockId { get; set; }
        public StockModel Stock { get; set; }

        public int Count { get; set; }
        public int AveragePrice { get; set; }
    }
}
