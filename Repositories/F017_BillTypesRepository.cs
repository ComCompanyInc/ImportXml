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
    public class F017_BillTypesRepository : AbstractBaseRepository<f017_BillTypes>, ISearchData<f017_BillTypes>
    {
        private readonly ApplicationDbContext _context;

        public F017_BillTypesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f017_BillTypes> GetEnitityByAttributes(f017_BillTypes entityData)
        {
            IQueryable<f017_BillTypes> f017_BillTypesResult = _context.F017_BillTypes;

            f017_BillTypes updatedF017_BillTypes = null;
            if (!entityData.f012_TipSchId.IsNullOrEmpty())
            {
                if (entityData.Subject != null
                    && !entityData.Subject.Okato.IsNullOrEmpty())
                {
                    f017_BillTypesResult = f017_BillTypesResult
                        .Where(c => c.f012_TipSchId == entityData.f012_TipSchId
                            && c.Subject.Okato == entityData.Subject.Okato);

                    f017_BillTypes existingF017_BillTypes = await f017_BillTypesResult.FirstOrDefaultAsync();
                    if (existingF017_BillTypes != null)
                    {
                        updatedF017_BillTypes = await UpdateObject(existingF017_BillTypes, entityData);
                    }
                }
            }

            return updatedF017_BillTypes;
        }

        public async Task<f017_BillTypes> UpdateObject(f017_BillTypes existingEntity, f017_BillTypes entityData)
        {
            if (!entityData.BudgetSource.IsNullOrEmpty()
                && entityData.BudgetSource != existingEntity.BudgetSource)
            {
                existingEntity.BudgetSource = entityData.BudgetSource;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (entityData.OrgTypeId != null
                && entityData.OrgTypeId != 0
                && entityData.OrgTypeId != existingEntity.OrgTypeId)
            {
                existingEntity.OrgTypeId = entityData.OrgTypeId;
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
