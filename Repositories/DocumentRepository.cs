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
    public class DocumentRepository : AbstractBaseRepository<Document>, ISearchData<Document>
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Document> GetEnitityByAttributes(Document entityData)
        {
            IQueryable<Document> documentResult = _context.Documents;

            if (!entityData.Inn.IsNullOrEmpty())
            {
                documentResult = documentResult
                    .Where(c => c.Inn == entityData.Inn);
            }

            if (!entityData.Ogrn.IsNullOrEmpty())
            {
                documentResult = documentResult
                    .Where(c => c.Ogrn == entityData.Ogrn);
            }

            if (!entityData.Kpp.IsNullOrEmpty())
            {
                documentResult = documentResult
                    .Where(c => c.Kpp == entityData.Kpp);
            }

            return await documentResult.FirstOrDefaultAsync();
        }
    }
}
