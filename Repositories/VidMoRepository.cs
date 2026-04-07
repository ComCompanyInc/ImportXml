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
    public class VidMoRepository : AbstractBaseRepository<VidMo>, ISearchData<VidMo>
    {
        private readonly ApplicationDbContext _context;
        public VidMoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VidMo> GetEnitityByAttributes(VidMo entityData)
        {
            IQueryable<VidMo> vidMoResult = _context.VidMos;

            if (!entityData.Name.IsNullOrEmpty())
            {
                vidMoResult = vidMoResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await vidMoResult.FirstOrDefaultAsync();
        }
    }
}
