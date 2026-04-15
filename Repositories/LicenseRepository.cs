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

            if (entityData.Id != null && entityData.Id != 0)
            {
                licenseResult = licenseResult
                    .Where(c => c.Id == entityData.Id);
            }

            if (!entityData.LicenseNum.IsNullOrEmpty())
            {
                licenseResult = licenseResult
                    .Where(c => c.LicenseNum == entityData.LicenseNum);
            }

            if (entityData.Dstart != null && entityData.Dstart != default(DateTime))
            {
                licenseResult = licenseResult
                    .Where(c => c.Dstart == entityData.Dstart);
            }

            if (entityData.DateE != null && entityData.DateE != default(DateTime))
            {
                licenseResult = licenseResult
                    .Where(c => c.DateE == entityData.DateE);
            }

            if (entityData.Dterm != null && entityData.Dterm != default(DateTime))
            {
                licenseResult = licenseResult
                    .Where(c => c.Dterm == entityData.Dterm);
            }

            return await licenseResult.FirstOrDefaultAsync();
        }
    }
}
