using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
        void Create(T item);
        Task CreateAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
