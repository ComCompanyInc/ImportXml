using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BackendApp.Repositories
{
    public class OidTypeRepository : AbstractBaseRepository<OidType>, ISearchData<OidType>
    {
        private readonly ApplicationDbContext _context;

        public OidTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<object>> GetDataBySearchFilter(Dictionary<string, object> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<OidType> GetEnitityByAttributes(OidType entityData)
        {
            IQueryable<OidType> oidTypeResult = _context.OidTypes;

            if (!entityData.Name.IsNullOrEmpty()) {
                oidTypeResult = oidTypeResult.Where(c => c.Name == entityData.Name);
            }

            return await oidTypeResult.FirstOrDefaultAsync();
        }

        public Task<OidType> UpdateObject(OidType existingEntity, OidType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
