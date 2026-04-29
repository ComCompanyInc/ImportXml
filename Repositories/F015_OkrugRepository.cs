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
    public class F015_OkrugRepository : AbstractBaseRepository<f015_Okrug>, ISearchData<f015_Okrug>
    {
        private readonly ApplicationDbContext _context;

        public F015_OkrugRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f015_Okrug> GetEnitityByAttributes(f015_Okrug entityData)
        {
            IQueryable<f015_Okrug> f015_OcrugResult = _context.F015_Okrugs;

            f015_Okrug updatedF015_Okrug = null;
            if (!entityData.Code.IsNullOrEmpty())
            {
                f015_OcrugResult = f015_OcrugResult
                    .Where(c => c.Code == entityData.Code);

                f015_Okrug existingF015_Okrug = await f015_OcrugResult.FirstOrDefaultAsync();
                if (existingF015_Okrug != null)
                {
                    updatedF015_Okrug = await UpdateObject(existingF015_Okrug, entityData);
                }
            }

            return updatedF015_Okrug;
        }

        public async Task<f015_Okrug> UpdateObject(f015_Okrug existingEntity, f015_Okrug entityData)
        {
            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (entityData.DistrictId != null
                && entityData.DistrictId != 0
                && entityData.DistrictId != existingEntity.DistrictId)
            {
                existingEntity.DistrictId = entityData.DistrictId;
            }

            if (entityData.DateBeg != null
                && entityData.DateBeg != default(DateTime)
                && entityData.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            return existingEntity;
        }
    }
}
