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
    public class F002_InsIncludeRepository : AbstractBaseRepository<f002_InsInclude>, ISearchData<f002_InsInclude>
    {
        private readonly ApplicationDbContext _context;

        public F002_InsIncludeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f002_InsInclude> GetEnitityByAttributes(f002_InsInclude entityData)
        {
            IQueryable<f002_InsInclude> insIncludeResult = _context.InsIncludes;

            if (!entityData.NameE.IsNullOrEmpty())
            {
                insIncludeResult = insIncludeResult
                    .Where(c => c.NameE == entityData.NameE);
            }

            if (!entityData.NalP.IsNullOrEmpty())
            {
                insIncludeResult = insIncludeResult
                    .Where(c => c.NalP == entityData.NalP);
            }

            //if (entityData.OrganizationId != null && entityData.OrganizationId != 0)
            //{
            //    insIncludeResult = insIncludeResult
            //        .Where(c => c.OrganizationId == entityData.OrganizationId);
            //}

            if (entityData.DBegin != null && entityData.DBegin != default(DateTime))
            {
                insIncludeResult = insIncludeResult
                    .Where(c => c.DBegin == entityData.DBegin);
            }

            if (entityData.DEnd != null && entityData.DEnd != default(DateTime))
            {
                insIncludeResult = insIncludeResult
                    .Where(c => c.DEnd == entityData.DEnd);
            }

            return await insIncludeResult.FirstOrDefaultAsync();
        }

        public Task<f002_InsInclude> UpdateObject(f002_InsInclude existingEntity, f002_InsInclude entityData)
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetDataBySearchFilter(Dictionary<string, object> filter)
        {
            IQueryable<f002_InsInclude> insIncludes = _context.InsIncludes;

            /*if (!FilterDto.NameE.IsNullOrEmpty())
            {
                insIncludes = insIncludes
                    .Where(c =>
                        c.NameE == c.NameE
                    );
            }

            if (!FilterDto.NalP.IsNullOrEmpty())
            {
                insIncludes = insIncludes
                    .Where(c =>
                        c.NalP == c.NalP
                    );
            }

            if (
                (FilterDto.DBegin != null
                    && FilterDto.DBegin != default(DateTime))
                && (FilterDto.DEnd != null
                    && FilterDto.DEnd != default(DateTime))
            )
            {
                insIncludes = insIncludes
                    .Where(c =>
                        c.DBegin >= FilterDto.DBegin
                        && c.DEnd <= FilterDto.DEnd
                    );
            }
            else
            {
                if (FilterDto.DBegin != null
                    && FilterDto.DBegin != default(DateTime)
                )
                {
                    insIncludes = insIncludes
                        .Where(c =>
                            c.DBegin == FilterDto.DBegin
                        );
                }

                if (FilterDto.DEnd != null
                    && FilterDto.DEnd != default(DateTime)
                )
                {
                    insIncludes = insIncludes
                        .Where(c =>
                            c.DEnd == FilterDto.DEnd
                        );
                }
            }*/

            return await insIncludes.Cast<object>().ToListAsync(); // ИЗМЕНИТЬ НА ВЫВОД КОНКРЕТНЫХ ПОЛЕЙ!
        }
    }
}
