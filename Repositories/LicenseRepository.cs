using BackendApp.Data;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BackendApp.Repositories
{
    public class LicenseRepository : AbstractBaseRepository<Models.License>, ISearchData<Models.License>
    {
        private readonly ApplicationDbContext _context;

        public LicenseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Models.License> GetEnitityByAttributes(Models.License entityData)
        {
            IQueryable<Models.License> licenseResult = _context.Licenses;

            //if (entityData.Id != null && entityData.Id != 0)
            //{
            //    licenseResult = licenseResult
            //        .Where(c => c.Id == entityData.Id);
            //}

            Models.License updatedLicense = null;
            if (!entityData.LicenseNum.IsNullOrEmpty())
            {
                licenseResult = licenseResult
                    .Where(c => c.LicenseNum == entityData.LicenseNum);
            }

            Models.License existingLicense = await licenseResult.FirstOrDefaultAsync();
            if (existingLicense != null)
            {
                updatedLicense = await UpdateObject(existingLicense, entityData);
            }

            //if (entityData.Dstart != null && entityData.Dstart != default(DateTime))
            //{
            //    licenseResult = licenseResult
            //        .Where(c => c.Dstart == entityData.Dstart);
            //}

            //if (entityData.DateE != null && entityData.DateE != default(DateTime))
            //{
            //    licenseResult = licenseResult
            //        .Where(c => c.DateE == entityData.DateE);
            //}

            //if (entityData.Dterm != null && entityData.Dterm != default(DateTime))
            //{
            //    licenseResult = licenseResult
            //        .Where(c => c.Dterm == entityData.Dterm);
            //}

            return updatedLicense;
        }

        public async Task<Models.License> UpdateObject(Models.License existingEntity, Models.License entityData)
        {
            if (entityData.Dstart != null && entityData.Dstart != default(DateTime))
            {
                existingEntity.Dstart = entityData.Dstart;
            }

            if (entityData.DateE != null && entityData.DateE != default(DateTime))
            {
                existingEntity.DateE = entityData.DateE;
            }

            if (entityData.Dterm != null && entityData.Dterm != default(DateTime))
            {
                existingEntity.Dterm = entityData.Dterm;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
