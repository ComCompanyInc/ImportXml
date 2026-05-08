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
    public class F019_PersAccOrgRepository : AbstractBaseRepository<f019_PersAccOrg>, ISearchData<f019_PersAccOrg>
    {
        private readonly ApplicationDbContext _context;

        public F019_PersAccOrgRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f019_PersAccOrg> GetEnitityByAttributes(f019_PersAccOrg entityData)
        {
            IQueryable<f019_PersAccOrg> f019_PersAccOrgResult = _context.F019_PersAccOrgs;

            f019_PersAccOrg updatedF019_PersAccOrg = null;
            if (entityData.Organization != null
                && !entityData.Organization.OrgCode.IsNullOrEmpty())
            {
                f019_PersAccOrgResult = f019_PersAccOrgResult
                    .Where(c => c.Organization.OrgCode == entityData.Organization.OrgCode);

                f019_PersAccOrg existingF019_PersAccOrg = await f019_PersAccOrgResult.FirstOrDefaultAsync();
                if (existingF019_PersAccOrg != null)
                {
                    updatedF019_PersAccOrg = await UpdateObject(existingF019_PersAccOrg, entityData);
                }
            }

            return updatedF019_PersAccOrg;
        }

        public async Task<f019_PersAccOrg> UpdateObject(f019_PersAccOrg existingEntity, f019_PersAccOrg entityData)
        {
            if (entityData.F001_TfomsId != null
                && entityData.F001_TfomsId != 0
                && entityData.F001_TfomsId != existingEntity.F001_TfomsId)
            {
                existingEntity.F001_TfomsId = entityData.F001_TfomsId;
            }

            /*if (entityData.F010_SubectiId != null
                && entityData.F010_SubectiId != 0
                && entityData.F010_SubectiId != existingEntity.F010_SubectiId)
            {
                existingEntity.F010_SubectiId = entityData.F010_SubectiId;
            }*/

            if (!entityData.F002_SmoEmpId.IsNullOrEmpty()
                && entityData.F002_SmoEmpId != existingEntity.F002_SmoEmpId)
            {
                existingEntity.F002_SmoEmpId = entityData.F002_SmoEmpId;
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
