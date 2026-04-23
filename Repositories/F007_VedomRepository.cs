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
    public class F007_VedomRepository : AbstractBaseRepository<f007_Vedom>, ISearchData<f007_Vedom>
    {
        private readonly ApplicationDbContext _context;

        public F007_VedomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f007_Vedom> GetEnitityByAttributes(f007_Vedom entityData)
        {
            IQueryable<f007_Vedom> f007_VedomResult = _context.F007_Vedoms;

            f007_Vedom updatedF007_Vedom = null;
            if (entityData.VedId != null && entityData.VedId != 0)
            {
                f007_VedomResult = f007_VedomResult
                    .Where(c => c.VedId == entityData.VedId);

                f007_Vedom existingEntity = await f007_VedomResult.FirstOrDefaultAsync();
                if (existingEntity != null)
                {
                    updatedF007_Vedom = await UpdateObject(existingEntity, entityData);
                }
            }

            return updatedF007_Vedom;
        }

        public async Task<f007_Vedom> UpdateObject(f007_Vedom existingEntity, f007_Vedom entityData)
        {
            if (entityData.VedomTypeId != null
                && entityData.VedomTypeId != 0
                && entityData.VedomTypeId != existingEntity.VedomTypeId)
            {
                existingEntity.VedomTypeId = entityData.VedomTypeId;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
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
