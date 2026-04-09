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
    public class DistrictRepository : AbstractBaseRepository<District>, ISearchData<District>
    {
        private readonly ApplicationDbContext _context;

        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<District> GetEnitityByAttributes(District entityData)
        {
            IQueryable<District> documentResult = _context.Districts;

            if (!entityData.Name.IsNullOrEmpty())
            {
                documentResult = documentResult
                    .Where(c => c.Name == entityData.Name);
            }

            if (entityData.DateBegin != default(DateTime))
            {
                documentResult = documentResult
                    .Where(c => c.DateBegin == entityData.DateBegin);
            }

            if (entityData.DateEnd != default(DateTime))
            {
                documentResult = documentResult
                    .Where(c => c.DateEnd == entityData.DateEnd);
            }

            if (entityData.SubjectId != null && entityData.SubjectId != 0)
            {
                documentResult = documentResult
                    .Where(c => c.SubjectId == entityData.SubjectId);
            }

            return await documentResult.FirstOrDefaultAsync();
        }
    }
}
