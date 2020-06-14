using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Repository.IRepository
{
    public interface IGenericRepository<T> : IGenericLogger<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        Task<bool> SaveAll();

    }
}
