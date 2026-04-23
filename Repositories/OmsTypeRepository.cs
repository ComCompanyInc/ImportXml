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
    public class OmsTypeRepository : AbstractBaseRepository<OmsType>, ISearchData<OmsType>
    {
        private readonly ApplicationDbContext _context;

        public OmsTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OmsType> GetEnitityByAttributes(OmsType entityData)
        {
            IQueryable<OmsType> omsTypeResult = _context.OmsTypes;

            if (!entityData.Name.IsNullOrEmpty())
            {
                omsTypeResult = omsTypeResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await omsTypeResult.FirstOrDefaultAsync();
        }

        public Task<OmsType> UpdateObject(OmsType existingEntity, OmsType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
