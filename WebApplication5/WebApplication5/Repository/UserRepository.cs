using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
        {
        private readonly UserTaskContext _userTaskContext;

        public UserRepository(UserTaskContext userTaskContext): base(userTaskContext)
        {
            _userTaskContext = userTaskContext;
        }
    }

}
