using FinancialPortfolioConsoleApp.BL.Models;

namespace FinancialPortfolioConsoleApp.BL.Interfaces
{
    internal interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        void Add(DbModel entity);
        List<DbModel> GetAll();
        DbModel? GetById(int id);
        void Remove(int id);
    }
}