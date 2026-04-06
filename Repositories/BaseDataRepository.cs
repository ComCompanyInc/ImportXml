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
    public class BaseDataRepository : AbstractBaseRepository<BaseData>, ISearchData<BaseData>
    {
        private readonly ApplicationDbContext _context;

        public BaseDataRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseData> GetEnitityByAttributes(BaseData entityData)
        {
            IQueryable<BaseData> basaeDataResult = _context.BaseData; //IQueryable<> - сохраняет состояние запросов (where и тд) в отличае от DbSet

            if (!entityData.Version.IsNullOrEmpty())
            {
                basaeDataResult = basaeDataResult
                    .Where(c => c.Version == entityData.Version);
            }

            if (!entityData.Type.IsNullOrEmpty())
            {
                basaeDataResult = basaeDataResult
                    .Where(c => c.Type == entityData.Type);
            }

            if (entityData.Date != default(DateTime))
            {
                basaeDataResult = basaeDataResult
                    .Where(c => c.Date == entityData.Date);
            }

            return await basaeDataResult.FirstOrDefaultAsync();
        }
    }
}
