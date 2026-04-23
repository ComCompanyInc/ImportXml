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

            Document updatedDocument = null;
            if (!entityData.Inn.IsNullOrEmpty())
            {
                documentResult = documentResult
                    .Where(c => c.Inn == entityData.Inn);

                Document existingDocument = await documentResult.FirstOrDefaultAsync();
                if (existingDocument != null) {
                    updatedDocument = await UpdateObject(existingDocument, entityData);
                }
            }

            //if (!entityData.Ogrn.IsNullOrEmpty())
            //{
            //    documentResult = documentResult
            //        .Where(c => c.Ogrn == entityData.Ogrn);
            //}

            //if (!entityData.Kpp.IsNullOrEmpty())
            //{
            //    documentResult = documentResult
            //        .Where(c => c.Kpp == entityData.Kpp);
            //}

            return updatedDocument;
        }

        public async Task<Document> UpdateObject(Document existingEntity, Document entityData)
        {
            if (!entityData.Ogrn.IsNullOrEmpty()
                && entityData.Ogrn != existingEntity.Ogrn)
            {
                existingEntity.Ogrn = entityData.Ogrn;
            }

            if (!entityData.Kpp.IsNullOrEmpty()
                && entityData.Kpp != existingEntity.Kpp)
            {
                existingEntity.Kpp = entityData.Kpp;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
