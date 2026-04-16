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
    public class F033_SpmoRepository : AbstractBaseRepository<f033_spmo>, ISearchData<f033_spmo>
    {
        public ApplicationDbContext _context;

        public F033_SpmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f033_spmo> GetEnitityByAttributes(f033_spmo entityData)
        {
            IQueryable<f033_spmo> f033_Spmos = _context.F033_Spmos;

            f033_spmo updatedF033_Spmo = null;
            if (!entityData.Id.IsNullOrEmpty())
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.Id == entityData.Id);

                f033_spmo existingF033_Spmo = await f033_Spmos.FirstOrDefaultAsync();
                if (existingF033_Spmo != null)
                {
                    updatedF033_Spmo = await UpdateObject(existingF033_Spmo, entityData);
                }
            }

            //if (!entityData.Code.IsNullOrEmpty())
            //{
            //    f033_Spmos = f033_Spmos
            //        .Where(c => c.Code == entityData.Code);
            //}

            //if (entityData.OspTypeId != null && entityData.OspTypeId != 0)
            //{
            //    f033_Spmos = f033_Spmos
            //        .Where(c => c.OspTypeId == entityData.OspTypeId);
            //}

            //if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            //{
            //    f033_Spmos = f033_Spmos
            //        .Where(c => c.OrgDocumentId == entityData.OrgDocumentId);
            //}

            //if (entityData.DateBeg != default(DateTime) && entityData.DateBeg != null)
            //{
            //    f033_Spmos = f033_Spmos
            //        .Where(c => c.DateBeg == entityData.DateBeg);
            //}

            //if (entityData.DateEnd != default(DateTime) && entityData.DateEnd != null)
            //{
            //    f033_Spmos = f033_Spmos
            //        .Where(c => c.DateEnd == entityData.DateEnd);
            //}

            return updatedF033_Spmo;
        }

        public async Task<f033_spmo> UpdateObject(f033_spmo existingEntity, f033_spmo entityData)
        {
            if (!entityData.Code.IsNullOrEmpty())
            {
                existingEntity.Code = entityData.Code;
            }

            if (entityData.OspTypeId != null && entityData.OspTypeId != 0)
            {
                existingEntity.OspTypeId = entityData.OspTypeId;
            }

            if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.DateBeg != default(DateTime) && entityData.DateBeg != null)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (entityData.DateEnd != default(DateTime) && entityData.DateEnd != null)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
