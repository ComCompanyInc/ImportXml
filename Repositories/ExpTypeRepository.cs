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
    public class ExpTypeRepository : AbstractBaseRepository<ExpType>, ISearchData<ExpType>
    {
        public ApplicationDbContext _context;

        public ExpTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExpType> GetEnitityByAttributes(ExpType entityData)
        {
            IQueryable<ExpType> expTypeResult = _context.ExpTypes;

            if (!entityData.Name.IsNullOrEmpty())
            {
                expTypeResult = expTypeResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await expTypeResult.FirstOrDefaultAsync();
        }

        public Task<ExpType> UpdateObject(ExpType existingEntity, ExpType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
