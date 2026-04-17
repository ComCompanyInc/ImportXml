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
    public class F037_LicmoRepository : AbstractBaseRepository<f037_licmo>, ISearchData<f037_licmo>
    {
        private readonly ApplicationDbContext _context;

        public F037_LicmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f037_licmo> GetEnitityByAttributes(f037_licmo entityData)
        {
            IQueryable<f037_licmo> f037_LicmosResult = _context.F037_Licmos;

            //if (entityData.Id != null && entityData.Id != 0)
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.Id == entityData.Id);
            //}

            //if (!entityData.F031_ErmoId.IsNullOrEmpty())
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.F031_Ermo == entityData.F031_Ermo);
            //}

            //if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.OrgDocumentId == entityData.OrgDocumentId);
            //}

            //if (entityData.OrganizationId != null && entityData.OrganizationId != 0)
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.OrganizationId == entityData.OrganizationId);
            //}

            f037_licmo updatedF037_Licmo = null;
            if (!entityData.F032_TrmoId.IsNullOrEmpty()) // UIDMO
            {
                f037_LicmosResult = f037_LicmosResult
                    .Where(c => c.F032_TrmoId == entityData.F032_TrmoId);
            }

            if (!entityData.License.LicenseNum.IsNullOrEmpty()) // N_DOC
            {
                f037_LicmosResult = f037_LicmosResult
                    .Where(c => c.License.LicenseNum == entityData.License.LicenseNum);
            }

            f037_licmo existingF037_Licmo = await f037_LicmosResult.FirstOrDefaultAsync();
            if (existingF037_Licmo != null)
            {
                updatedF037_Licmo = await UpdateObject(existingF037_Licmo, entityData);
            }

            //if (entityData.LicenseId != null && entityData.LicenseId != 0)
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.LicenseId == entityData.LicenseId);
            //}

            //if (entityData.DateBeg != null && entityData.DateBeg != default(DateTime))
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.DateBeg == entityData.DateBeg);
            //}

            //if (entityData.DateEnd != null && entityData.DateEnd != default(DateTime))
            //{
            //    f037_LicmosResult = f037_LicmosResult
            //        .Where(c => c.DateEnd == entityData.DateEnd);
            //}

            return updatedF037_Licmo;
        }

        public async Task<f037_licmo> UpdateObject(f037_licmo existingEntity, f037_licmo entityData)
        {
            if (!entityData.F031_ErmoId.IsNullOrEmpty())
            {
                existingEntity.F031_ErmoId = entityData.F031_ErmoId;
            }

            if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.OrganizationId != null && entityData.OrganizationId != 0)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.LicenseId != null && entityData.LicenseId != 0)
            {
                existingEntity.LicenseId = entityData.LicenseId;
            }

            if (entityData.DateBeg != null && entityData.DateBeg != default(DateTime))
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (entityData.DateEnd != null && entityData.DateEnd != default(DateTime))
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
