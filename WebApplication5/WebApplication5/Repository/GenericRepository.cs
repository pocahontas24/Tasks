
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Repository
{
    public class GenericRepository<T> :  GenericLogger<T>, IGenericRepository<T> where T : class, IEntity
    {
        private readonly UserTaskContext _userTaskContext;

        public GenericRepository(UserTaskContext userTaskContext) :base(userTaskContext)
        {
            _userTaskContext = userTaskContext;
        }
        public void Add(T entity)
        {
            _userTaskContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _userTaskContext.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _userTaskContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var returnList =  await _userTaskContext.Set<T>().ToListAsync();
            return returnList;
        }


        public async Task<T> GetById(int id)
        {
            return await _userTaskContext.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
        }

        public void Update(T entity)
        {
            _userTaskContext.Update(entity);
        }
    }
}
