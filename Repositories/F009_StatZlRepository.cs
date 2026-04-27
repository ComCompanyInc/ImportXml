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
    public class F009_StatZlRepository : AbstractBaseRepository<f009_StatZl>, ISearchData<f009_StatZl>
    {
        private readonly ApplicationDbContext _context;

        public F009_StatZlRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f009_StatZl> GetEnitityByAttributes(f009_StatZl entityData)
        {
            IQueryable<f009_StatZl> f009_StatZlResult = _context.F009_StatZls;

            f009_StatZl updatedF009_StatZl = null;
            if (entityData.StatusId != null
                && entityData.StatusId != 0)
            {
                f009_StatZlResult = f009_StatZlResult
                    .Where(c => c.StatusId == entityData.StatusId);

                f009_StatZl existingF009_StatZl = await f009_StatZlResult.FirstOrDefaultAsync();
                if (existingF009_StatZl != null)
                {
                    updatedF009_StatZl = await UpdateObject(existingF009_StatZl, entityData);
                }
            }

            return updatedF009_StatZl;
        }

        public async Task<f009_StatZl> UpdateObject(f009_StatZl existingEntity, f009_StatZl entityData)
        {
            if (existingEntity.StatTypeId != null
                && existingEntity.StatTypeId != 0
                && existingEntity.StatTypeId != existingEntity.StatTypeId)
            {
                existingEntity.StatTypeId = entityData.StatTypeId;
            }

            if (existingEntity.BaseDataId != null
                && existingEntity.BaseDataId != 0
                && existingEntity.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (existingEntity.DateBeg != null
                && existingEntity.DateBeg != default(DateTime)
                && existingEntity.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (existingEntity.DateEnd != null
                && existingEntity.DateEnd != default(DateTime)
                && existingEntity.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
