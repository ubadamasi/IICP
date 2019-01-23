using App.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Data
{
    public interface IAuthRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<Value>> GetValues();
        Task<Value> GetValue(int id);
        Task<bool> SaveAll();

    }
}
