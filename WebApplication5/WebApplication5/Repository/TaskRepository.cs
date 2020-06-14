using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Repository
{
    public class TaskRepository : GenericRepository<Models.Task>, ITaskRepository
    {
        private readonly UserTaskContext _userTaskContext;

        public TaskRepository(UserTaskContext userTaskContext) : base(userTaskContext)
        {
            _userTaskContext = userTaskContext;
        }

        public async Task<IEnumerable<Models.Task>> GetAllWithUser()
        {
            return await _userTaskContext.Set<Models.Task>().Include(e => e.User).ToListAsync();
        }
        public async Task<Models.Task> GetByIdWithUser(int id)
        {
            return await _userTaskContext.Set<Models.Task>().Include(e => e.User).FirstOrDefaultAsync(e => e.ID == id);
        }
    }
}
