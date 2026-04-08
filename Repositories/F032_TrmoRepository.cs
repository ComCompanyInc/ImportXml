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
    public class F032_TrmoRepository : AbstractBaseRepository<f032_trmo>, ISearchData<f032_trmo>
    {
        private readonly ApplicationDbContext _context;

        public F032_TrmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f032_trmo> GetEnitityByAttributes(f032_trmo entityData)
        {
            IQueryable<f032_trmo> f032_TrmosResult = _context.F032_Trmos;

            if (!entityData.Id.IsNullOrEmpty()) {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.Id == entityData.Id);
            }

            if (entityData.OrganizationId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.OrganizationId == entityData.OrganizationId);
            }

            if (entityData.AddressId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.AddressId == entityData.AddressId);
            }

            if (entityData.DocumentId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.DocumentId == entityData.DocumentId);
            }

            if (entityData.OspTypeId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.OspTypeId == entityData.OspTypeId);
            }

            if (entityData.ExclusionDate != default(DateTime))
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.ExclusionDate == entityData.ExclusionDate);
            }

            if (entityData.InclusionDate != default(DateTime))
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.InclusionDate == entityData.InclusionDate);
            }

            if (entityData.MoDocumentId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.MoDocumentId == entityData.MoDocumentId);
            }

            if (entityData.DateBeg != default(DateTime))
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.DateBeg == entityData.DateBeg);
            }

            if (entityData.DateEnd != default(DateTime))
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.DateEnd == entityData.DateEnd);
            }

            if (entityData.CommunicationId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.CommunicationId == entityData.CommunicationId);
            }

            if (entityData.BaseDataId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.BaseDataId == entityData.BaseDataId);
            }

            if (entityData.ParentId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.ParentId == entityData.ParentId);
            }

            if (entityData.f031_ermoId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.f031_ermoId == entityData.f031_ermoId);
            }

            if (entityData.f031_ermoParentId != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.f031_ermoParentId == entityData.f031_ermoParentId);
            }

            if (entityData.DateBeginOms != null)
            {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.DateBeginOms == entityData.DateBeginOms);
            }

            return await f032_TrmosResult.FirstOrDefaultAsync();
        }
    }
}
