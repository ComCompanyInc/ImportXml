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
    public class F008_TipOmsRepository : AbstractBaseRepository<f008_TipOms>, ISearchData<f008_TipOms>
    {
        private readonly ApplicationDbContext _context;

        public F008_TipOmsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f008_TipOms> GetEnitityByAttributes(f008_TipOms entityData)
        {
            IQueryable<f008_TipOms> f008_TipOmsResult = _context.F008_TipOms;

            f008_TipOms updatedF008_TipOms = null;
            if (entityData.DocId != null && entityData.DocId != 0)
            {
                f008_TipOmsResult = f008_TipOmsResult
                    .Where(c => c.DocId == entityData.DocId);
            
                f008_TipOms existingF008_TipOms = await f008_TipOmsResult.FirstOrDefaultAsync();
                if (existingF008_TipOms != null)
                {
                    updatedF008_TipOms = await UpdateObject(existingF008_TipOms, entityData);
                }
            }

            return updatedF008_TipOms;
        }

        public async Task<f008_TipOms> UpdateObject(f008_TipOms existingEntity, f008_TipOms entityData)
        {
            if (entityData.OmsTypeId != null
                && entityData.OmsTypeId != 0
                && entityData.OmsTypeId != existingEntity.OmsTypeId)
            {
                existingEntity.OmsTypeId = entityData.OmsTypeId;
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
    }
}
