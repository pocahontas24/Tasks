using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Repository.IRepository
{
    public interface IGenericLogger<T> where T : class
    {
        Task<bool> LogCreateAction(T entity);
        Task<bool> LogUpdateAction(T newEntity, string oldEntity);
        Task<bool> LogDeleteAction(T entity);
    }
}
