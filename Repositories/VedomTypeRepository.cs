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
    public class VedomTypeRepository : AbstractBaseRepository<VedomType>, ISearchData<VedomType>
    {
        private readonly ApplicationDbContext _context;

        public VedomTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VedomType> GetEnitityByAttributes(VedomType entityData)
        {
            IQueryable<VedomType> vedomTypeResult = _context.VedomType;

            if (!entityData.Name.IsNullOrEmpty())
            {
                vedomTypeResult = vedomTypeResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await vedomTypeResult.FirstOrDefaultAsync();
        }

        public Task<VedomType> UpdateObject(VedomType existingEntity, VedomType entityData)
        {
            throw new NotImplementedException();
        }
    }
}
