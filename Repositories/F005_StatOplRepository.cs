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
    public class F005_StatOplRepository : AbstractBaseRepository<f005_StatOpl>, ISearchData<f005_StatOpl>
    {
        private readonly ApplicationDbContext _context;

        public F005_StatOplRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f005_StatOpl> GetEnitityByAttributes(f005_StatOpl entityData)
        {
            IQueryable<f005_StatOpl> f005_StatOplResult = _context.F005_StatOpls;

            f005_StatOpl updatedF005_StatOpl = null;
            if (entityData.StatusCode != null && entityData.StatusCode != 0)
            {
                f005_StatOplResult = f005_StatOplResult
                    .Where(c => c.StatusCode == entityData.StatusCode);

                f005_StatOpl existingF005_StatOpl = await f005_StatOplResult.FirstOrDefaultAsync();
                if (existingF005_StatOpl != null)
                {
                    updatedF005_StatOpl = await UpdateObject(existingF005_StatOpl, entityData);
                }
            }

            return updatedF005_StatOpl;
        }

        public async Task<f005_StatOpl> UpdateObject(f005_StatOpl existingEntity, f005_StatOpl entityData)
        {
            if (entityData.PaymentStatusId != null
                && entityData.PaymentStatusId != 0
                && entityData.PaymentStatusId != existingEntity.PaymentStatusId)
            {
                existingEntity.PaymentStatusId = entityData.PaymentStatusId;
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
