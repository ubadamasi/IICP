using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Main.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Main.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _db;

        public AuthRepository(DataContext db)
        {
            _db = db;
        }
        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _db.Values.FirstOrDefaultAsync(x => x.Id == id);
            return value;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            var values = await _db.Values.ToListAsync();
            return values;
        }

        public async Task<bool> SaveAll()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
