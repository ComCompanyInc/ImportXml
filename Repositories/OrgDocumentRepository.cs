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
    public class OrgDocumentRepository : AbstractBaseRepository<OrgDocument>, ISearchData<OrgDocument>
    {
        private readonly ApplicationDbContext _context;

        public OrgDocumentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrgDocument> GetEnitityByAttributes(OrgDocument entityData)
        {
            IQueryable<OrgDocument> moDocumentResult = _context.OrgDocuments;

            if (entityData.Id != null && entityData.Id != 0)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.Id == entityData.Id);
            }

            if (entityData.OidTypeMoId != null && entityData.OidTypeMoId != 0)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.OidTypeMoId == entityData.OidTypeMoId);
            }

            if (entityData.OidTypeSpmoId != null && entityData.OidTypeSpmoId != 0)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.OidTypeSpmoId == entityData.OidTypeSpmoId);
            }

            if (!entityData.Okfs.IsNullOrEmpty())
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.Okfs == entityData.Okfs);
            }

            if (entityData.VidTypeId != null && entityData.VidTypeId != 0)
            {
                moDocumentResult = moDocumentResult
                    .Where(c => c.VidTypeId == entityData.VidTypeId);
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
