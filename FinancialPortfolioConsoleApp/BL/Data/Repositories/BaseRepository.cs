using FinancialPortfolioConsoleApp.BL.Interfaces;
using FinancialPortfolioConsoleApp.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioConsoleApp.BL.Data.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<DbModel> _entities;

        /// <summary>
        /// Базовый конструктор BaseRepository.
        /// </summary>
        /// <param name="appDbContext">DbContext</param>
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<DbModel>();
        }

        /// <summary>
        /// Добавить сущность.
        /// </summary>
        /// <param name="entity">Модель сущности.</param>
        public virtual void Add(DbModel entity)
        {
            _entities.Add(entity);
            _appDbContext.SaveChanges();
        }
        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="id">id сущности, которую хотите удалить</param>
        /// <returns>true - сущность удалена. false - сущность удалить не удалось.</returns>
        public bool Remove(int id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                _entities.Remove(entity);
                _appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        public virtual List<DbModel> GetAll()
        {
            return _entities.ToList();
        }
        /// <summary>
        /// Получить сущность по id.
        /// </summary>
        /// <param name="id">id сущности.</param>
        /// <returns>Сущность.</returns>
        public virtual DbModel? GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }
    }
}
