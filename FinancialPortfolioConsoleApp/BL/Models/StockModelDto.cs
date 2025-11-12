using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioConsoleApp.BL.Models
{
    public class StockModelDto
    {
        public required string Ticker { get; set; }
        public required int Count { get; set; }
        public required int Price { get; set; }
    }
}
