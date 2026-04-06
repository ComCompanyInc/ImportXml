using BackendApp.Data;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories.AbstractBase
{
    /// <summary>
    /// Универсальный класс для управления сущностями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractBaseRepository<T> where T: class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public AbstractBaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // получаем нужный нам DbSet для указанного типа класса T
        }

        public async Task<T> SaveData(T obj)
        {
            if (obj != null)
            {
                await _dbSet.AddAsync(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            else
            {
                return null;
            }
        }
    }
}
