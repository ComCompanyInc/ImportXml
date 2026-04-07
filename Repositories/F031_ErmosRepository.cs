using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F031_ErmosRepository : AbstractBaseRepository<f031_ermo>
    {
        private readonly ApplicationDbContext _context;

        public F031_ErmosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f031_ermo> GetEnitityByAttributes(f031_ermo f031_ermoData)
        {
            IQueryable<f031_ermo> f031_ermoResult = _context.F031_Ermos;

            if (f031_ermoData.OrganizationId != null)
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.OrganizationId == f031_ermoData.OrganizationId);
            }

            if (f031_ermoData.MoDocumentId != null)
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.MoDocumentId == f031_ermoData.MoDocumentId);
            }

            if (f031_ermoData.AddressId != null)
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.AddressId == f031_ermoData.AddressId);
            }

            if (f031_ermoData.BaseDataId != null)
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.BaseDataId == f031_ermoData.BaseDataId);
            }

            return await f031_ermoResult.FirstOrDefaultAsync();
        }
    }
}
