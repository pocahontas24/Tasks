using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Repository.IRepository
{
    public interface ITaskRepository : IGenericRepository<Models.Task>
    {
        public Task<IEnumerable<Models.Task>> GetAllWithUser();
        public Task<Models.Task> GetByIdWithUser(int id);
    }
}
