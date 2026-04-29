using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F012_TipSchRepository : AbstractBaseRepository<f012_TipSch>, ISearchData<f012_TipSch>
    {
        private readonly ApplicationDbContext _context;
        public F012_TipSchRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f012_TipSch> GetEnitityByAttributes(f012_TipSch entityData)
        {
            IQueryable<f012_TipSch> f012_TipSchesResult = _context.F012_TipSches;

            f012_TipSch updatedF012_TipSch = null;
            if (!entityData.SchId.IsNullOrEmpty())
            {
                f012_TipSchesResult = f012_TipSchesResult
                    .Where(c => c.SchId == entityData.SchId);

                f012_TipSch existingF012_TipSch = await f012_TipSchesResult.FirstOrDefaultAsync();
                if (existingF012_TipSch != null)
                {
                    updatedF012_TipSch = await UpdateObject(existingF012_TipSch, entityData);
                }
            }

            return updatedF012_TipSch;
        }

        public async Task<f012_TipSch> UpdateObject(f012_TipSch existingEntity, f012_TipSch entityData)
        {
            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (!entityData.ShortName.IsNullOrEmpty()
                && entityData.ShortName != existingEntity.ShortName)
            {
                existingEntity.ShortName = entityData.ShortName;
            }

            if (!entityData.Name.IsNullOrEmpty()
                && entityData.Name != existingEntity.Name)
            {
                existingEntity.Name = entityData.Name;
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
