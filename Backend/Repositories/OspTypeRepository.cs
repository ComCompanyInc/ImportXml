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
    public class OspTypeRepository : AbstractBaseRepository<OspType>, ISearchData<OspType>
    {
        private readonly ApplicationDbContext _context;

        public OspTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OspType> GetEnitityByAttributes(OspType entityData)
        {
            IQueryable<OspType> ospTypeResult = _context.OspTypes;

            if (entityData.Name != null)
            {
                ospTypeResult = ospTypeResult
                    .Where(c => c.Name == entityData.Name);
            }

            return await ospTypeResult.FirstOrDefaultAsync();
        }

        public Task<OspType> UpdateObject(OspType existingEntity, OspType entityData)
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetDataBySearchFilter(OspType FilterDto)
        {
            IQueryable<OspType> ospType = _context.OspTypes;

            if (FilterDto.Name != null)
            {
                ospType = ospType
                    .Where(c =>
                        c.Name == FilterDto.Name
                    );
            }

            return await ospType.Cast<object>().ToListAsync(); // ИЗМЕНИТЬ НА ВЫВОД КОНКРЕТНЫХ ПОЛЕЙ!
        }
    }
}
