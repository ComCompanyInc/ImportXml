using BackendApp.Backend.Repositories.ExtensionBase;
using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F006_VidExpRepository : AbstractBaseRepository<f006_VidExp>, ISearchData<f006_VidExp>
    {
        private readonly ApplicationDbContext _context;
        private readonly BaseSearchMethods<f006_VidExp> _searchMethods; // композиция вспомогательного класса с методами для фильтрации сущности

        public F006_VidExpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _searchMethods = new BaseSearchMethods<f006_VidExp>(_context);
        }

        public async Task<f006_VidExp> GetEnitityByAttributes(f006_VidExp entityData)
        {
            IQueryable<f006_VidExp> f006_VidExpResult = _context.F006_VidExps;

            f006_VidExp updatedF006_VidExp = null;
            if (entityData.VidId != null && entityData.VidId != 0)
            {
                f006_VidExpResult = f006_VidExpResult
                    .Where(c => c.VidId == entityData.VidId);

                f006_VidExp existingF006_VidExp = await f006_VidExpResult.FirstOrDefaultAsync();
                if (existingF006_VidExp != null)
                {
                    updatedF006_VidExp = await UpdateObject(existingF006_VidExp, entityData);
                }
            }

            return updatedF006_VidExp;
        }

        public async Task<f006_VidExp> UpdateObject(f006_VidExp existingEntity, f006_VidExp entityData)
        {
            if (entityData.ExpTypeId != null
                && entityData.ExpTypeId != 0
                && entityData.ExpTypeId != existingEntity.ExpTypeId)
            {
                existingEntity.ExpTypeId = entityData.ExpTypeId;
            }

            if (entityData.ExpTypeId != null
                && entityData.ExpTypeId != 0
                && entityData.ExpTypeId != existingEntity.ExpTypeId)
            {
                existingEntity.ExpTypeId = entityData.ExpTypeId;
            }

            if (entityData.DateBeg != null
                && entityData.DateBeg != default(DateTime)
                && entityData.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (entityData.DateEnd != null
                && entityData.DateEnd != default(DateTime)
                && entityData.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<List<object>> GetDataBySearchFilter(Dictionary<string, object> filter)
        {
            // Вся сложная логика уже в BaseSearchMethods
            //IQueryable<f006_VidExp> query = await _searchMethods.GetDataBySearchFilter(FilterDto);

            //return await query.Cast<object>().ToListAsync(); // ИЗМЕНИТЬ НА ВЫВОД КОНКРЕТНЫХ ПОЛЕЙ!

            throw new NotImplementedException();
        }
    }
}
