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
    public class StatTypeRepository : AbstractBaseRepository<StatType>, ISearchData<StatType>
    {
        public ApplicationDbContext _context;

        public StatTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<StatType> GetEnitityByAttributes(StatType entityData)
        {
            IQueryable<StatType> statTypeResult = _context.StatTypes;

            if (!entityData.StatusName.IsNullOrEmpty())
            {
                statTypeResult = statTypeResult
                    .Where(c => c.StatusName == entityData.StatusName);
            }

            return await statTypeResult.FirstOrDefaultAsync();
        }

        public Task<StatType> UpdateObject(StatType existingEntity, StatType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
