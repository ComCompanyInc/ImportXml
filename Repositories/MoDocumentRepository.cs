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
    public class MoDocumentRepository : AbstractBaseRepository<MoDocument>, ISearchData<MoDocument>
    {
        private readonly ApplicationDbContext _context;

        public MoDocumentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MoDocument> GetEnitityByAttributes(MoDocument entityData)
        {
            IQueryable<MoDocument> moDocumentResult = _context.MoDocuments;

            if (entityData.Id != null)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.Id == entityData.Id);
            }

            if (!entityData.OidMo.IsNullOrEmpty())
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.OidMo == entityData.OidMo);
            }

            if (!entityData.Okfs.IsNullOrEmpty())
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.Okfs == entityData.Okfs);
            }

            if (entityData.VidMoId != null)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.VidMoId == entityData.VidMoId);
            }

            if (!entityData.OidSpmo.IsNullOrEmpty())
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.OidSpmo == entityData.OidSpmo);
            }

            if (entityData.DateBeg != default(DateTime))
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.DateBeg == entityData.DateBeg);
            }

            if (entityData.DateEnd != default(DateTime))
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.DateEnd == entityData.DateEnd);
            }

            return await moDocumentResult.FirstOrDefaultAsync();
        }
    }
}
