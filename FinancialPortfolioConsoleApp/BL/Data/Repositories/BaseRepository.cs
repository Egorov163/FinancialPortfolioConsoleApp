using FinancialPortfolioConsoleApp.BL.Interfaces;
using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<DbModel> _entities;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<DbModel>();
        }

        public virtual void Add(DbModel entity)
        {
            _entities.Add(entity);
            _appDbContext.SaveChanges();
        }
        public virtual void Remove(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _entities.Remove(entity);
                _appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Сущность с id {id} не найдена");
            }
        }
        public virtual List<DbModel> GetAll()
        {
            return _entities.ToList();
        }
        public virtual DbModel? GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }
    }
}
