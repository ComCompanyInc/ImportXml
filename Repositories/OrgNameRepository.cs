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
    public class OrgNameRepository : AbstractBaseRepository<OrgName>, ISearchData<OrgName>
    {
        private readonly ApplicationDbContext _context;

        public OrgNameRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<OrgName> GetEnitityByAttributes(OrgName entityData)
        {
            IQueryable<OrgName> orgNameResult = _context.OrgNames;

            if (!entityData.Name.IsNullOrEmpty()) {
                orgNameResult = orgNameResult
                    .Where(c => c.Name == entityData.Name);
            }

            if (!entityData.ShortName.IsNullOrEmpty())
            {
                orgNameResult = orgNameResult
                    .Where(c => c.ShortName == entityData.ShortName);
            }

            return orgNameResult.FirstOrDefaultAsync();
        }

        public Task<OrgName> UpdateObject(OrgName existingEntity, OrgName entityData)
        {
            throw new NotImplementedException();
        }
    }
}
