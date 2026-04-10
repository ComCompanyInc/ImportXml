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
    public class VidTypeRepository : AbstractBaseRepository<VidType>, ISearchData<VidType>
    {
        private readonly ApplicationDbContext _context;
        public VidTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VidType> GetEnitityByAttributes(VidType entityData)
        {
            IQueryable<VidType> vidMoResult = _context.VidTypes;

            if (!entityData.Name.IsNullOrEmpty())
            {
                vidMoResult = vidMoResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await vidMoResult.FirstOrDefaultAsync();
        }
    }
}
