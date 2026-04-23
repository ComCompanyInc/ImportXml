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
    public class F031_ErmosRepository : AbstractBaseRepository<f031_ermo>, ISearchData<f031_ermo>
    {
        private readonly ApplicationDbContext _context;

        public F031_ErmosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f031_ermo> GetEnitityByAttributes(f031_ermo f031_ermoData)
        {
            IQueryable<f031_ermo> f031_ermoResult = _context.F031_Ermos;

            f031_ermo updatedF031_Ermo = null;
            if (!f031_ermoData.Id.IsNullOrEmpty())
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.Id == f031_ermoData.Id);

                f031_ermo existingF031_Ermo = await f031_ermoResult.FirstOrDefaultAsync();
                if (existingF031_Ermo != null)
                {
                    updatedF031_Ermo = await UpdateObject(existingF031_Ermo, f031_ermoData);
                }
            }

            //if (f031_ermoData.OrganizationId != null && f031_ermoData.OrganizationId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.OrganizationId == f031_ermoData.OrganizationId);
            //}

            //if (f031_ermoData.OrgDocumentId != null && f031_ermoData.OrgDocumentId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.OrgDocumentId == f031_ermoData.OrgDocumentId);
            //}

            //if (f031_ermoData.AddressId != null && f031_ermoData.AddressId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.AddressId == f031_ermoData.AddressId);
            //}

            //if (f031_ermoData.BaseDataId != null && f031_ermoData.BaseDataId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.BaseDataId == f031_ermoData.BaseDataId);
            //}

            return updatedF031_Ermo;
        }

        public async Task<f031_ermo> UpdateObject(f031_ermo existingEntity, f031_ermo entityData)
        {
            if (entityData.OrganizationId != null
                && entityData.OrganizationId != 0
                && entityData.OrganizationId != existingEntity.OrganizationId)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.OrgDocumentId != null
                && entityData.OrgDocumentId != 0
                && entityData.OrgDocumentId != existingEntity.OrgDocumentId)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.AddressId != null
                && entityData.AddressId != 0
                && entityData.AddressId != existingEntity.AddressId)
            {
                existingEntity.AddressId = entityData.AddressId;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
