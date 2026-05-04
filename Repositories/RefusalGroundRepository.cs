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
    public class RefusalGroundRepository : AbstractBaseRepository<RefusalGround>, ISearchData<RefusalGround>
    {
        private readonly ApplicationDbContext _context;

        public RefusalGroundRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RefusalGround> GetEnitityByAttributes(RefusalGround entityData)
        {
            IQueryable<RefusalGround> refusalGround = _context.RefusalGrounds;

            if (!entityData.Name.IsNullOrEmpty())
            {
                refusalGround = refusalGround
                    .Where(c => c.Name == entityData.Name);
            }

            return await refusalGround.FirstOrDefaultAsync();
        }

        public Task<RefusalGround> UpdateObject(RefusalGround existingEntity, RefusalGround entityData)
        {
            throw new NotImplementedException();
        }
    }
}
