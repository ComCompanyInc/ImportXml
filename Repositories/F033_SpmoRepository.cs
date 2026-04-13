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
    public class F033_SpmoRepository : AbstractBaseRepository<f033_spmo>, ISearchData<f033_spmo>
    {
        public ApplicationDbContext _context;

        public F033_SpmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f033_spmo> GetEnitityByAttributes(f033_spmo entityData)
        {
            IQueryable<f033_spmo> f033_Spmos = _context.F033_Spmos;

            if (!entityData.Id.IsNullOrEmpty())
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.Id == entityData.Id);
            }

            if (!entityData.Code.IsNullOrEmpty())
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.Code == entityData.Code);
            }

            if (!entityData.Name.IsNullOrEmpty())
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.Name == entityData.Name);
            }

            if (!entityData.ShortName.IsNullOrEmpty())
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.ShortName == entityData.ShortName);
            }

            if (entityData.OspTypeId != null && entityData.OspTypeId != 0)
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.OspTypeId == entityData.OspTypeId);
            }

            if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.OrgDocumentId == entityData.OrgDocumentId);
            }

            if (entityData.DateBeg != default(DateTime))
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.DateBeg == entityData.DateBeg);
            }

            if (entityData.DateEnd != default(DateTime))
            {
                f033_Spmos = f033_Spmos
                    .Where(c => c.DateEnd == entityData.DateEnd);
            }

            return await f033_Spmos.FirstOrDefaultAsync();
        }
    }
}
