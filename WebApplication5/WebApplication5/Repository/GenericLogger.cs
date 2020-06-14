
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Repository
{
    public class GenericLogger<T> : IGenericLogger<T> where T : class
    {
        private static string createMessage = "Kreiran entitet: {entity}";
        private static string updateMessage = "Izmjenjen entitet: {oldEntity} na novu vrijednost: {newEntity}.";
        private static string deleteMessage = "Obrisan entitet : {entity}";

        private static readonly string CREATE = "CREATE";
        private static readonly string UPDATE = "UPDATE";
        private static readonly string DELETE = "DELETE";

        private readonly UserTaskContext _userTaskContext;
        private readonly Type type;

        // treba izvuci usera iz jwta
        public GenericLogger(UserTaskContext userTaskContext)
        {
            _userTaskContext = userTaskContext;
            type = typeof(T);
        }

        public async Task<bool> LogCreateAction(T entity)
        {
            var log = new Log()
            {
                ActionType = CREATE,
                ActionDetails = createMessage.Replace("{entity}", entity.ToString()),
                Created = DateTime.Now,
                UserId = 1
            };

            _userTaskContext.Log.Add(log);

            return await _userTaskContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> LogDeleteAction(T entity)
        {
            var log = new Log()
            {
                ActionType = DELETE,
                ActionDetails = deleteMessage.Replace("{entity}", entity.ToString()),
                Created = DateTime.Now,
                UserId = 1
            };

            _userTaskContext.Log.Add(log);

            return await _userTaskContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> LogUpdateAction(T newEntity, string oldEntity)
        {
            var log = new Log()
            {
                ActionType = UPDATE,
                ActionDetails = updateMessage.Replace("{oldEntity}", oldEntity).Replace("{newEntity}", newEntity.ToString()),
                Created = DateTime.Now,
                UserId = 1,
            };

            _userTaskContext.Log.Add(log);

            return await _userTaskContext.SaveChangesAsync() > 0;
        }

    }
}
