using LivrariaAPI_DIO.Models;

namespace LivrariaAPI_DIO.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        #region CRUD
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task Delete(Guid id);

        #endregion
    }
}
