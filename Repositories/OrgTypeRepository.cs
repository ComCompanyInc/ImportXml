using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class OrgTypeRepository : AbstractBaseRepository<OrgType>, ISearchData<OrgType>
    {
        private readonly ApplicationDbContext _context;

        public OrgTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrgType> GetEnitityByAttributes(OrgType entityData)
        {
            IQueryable<OrgType> orgTypeResult = _context.OrgTypes;

            if (entityData.OrgTypeName != null)
            {
                orgTypeResult = orgTypeResult
                    .Where(c => c.OrgTypeName == entityData.OrgTypeName);
            }

            return await orgTypeResult.FirstOrDefaultAsync();
        }

        public Task<OrgType> UpdateObject(OrgType existingEntity, OrgType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
