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

            //if (entityData.OrganizationId != null && entityData.OrganizationId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OrganizationId == entityData.OrganizationId);
            //}

            //if (entityData.AddressId != null && entityData.AddressId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.AddressId == entityData.AddressId);
            //}

            //if (entityData.DocumentId != null && entityData.DocumentId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DocumentId == entityData.DocumentId);
            //}

            //if (entityData.OspTypeId != null && entityData.OspTypeId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OspTypeId == entityData.OspTypeId);
            //}

            //if (entityData.ExclusionDate != default(DateTime) && entityData.ExclusionDate != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.ExclusionDate == entityData.ExclusionDate);
            //}

            //if (entityData.InclusionDate != default(DateTime) && entityData.InclusionDate != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.InclusionDate == entityData.InclusionDate);
            //}

            //if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OrgDocumentId == entityData.OrgDocumentId);
            //}

            //if (entityData.DateBeg != default(DateTime))
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateBeg == entityData.DateBeg);
            //}

            //if (entityData.DateEnd != default(DateTime) && entityData.DateEnd != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateEnd == entityData.DateEnd);
            //}

            //if (entityData.CommunicationId != null && entityData.CommunicationId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.CommunicationId == entityData.CommunicationId);
            //}

            //if (entityData.BaseDataId != null && entityData.BaseDataId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.BaseDataId == entityData.BaseDataId);
            //}

            //if (!entityData.ParentId.IsNullOrEmpty())
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.ParentId == entityData.ParentId);
            //}

            //if (!entityData.f031_ermoId.IsNullOrEmpty())
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.f031_ermoId == entityData.f031_ermoId);
            //}

            //if (entityData.f031_ermoParentId != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.f031_ermoParentId == entityData.f031_ermoParentId);
            //}

            //if (entityData.DateBeginOms != null && entityData.DateBeginOms != default(DateTime))
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateBeginOms == entityData.DateBeginOms);
            //}

            return await f032_TrmosResult.FirstOrDefaultAsync();
        }

        public async Task<f032_trmo> UpdateObject(f032_trmo existingEntity, f032_trmo entityData)
        {
            if (entityData.OrganizationId != null
                && entityData.OrganizationId != 0
                && entityData.OrganizationId != existingEntity.OrganizationId)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.AddressId != null
                && entityData.AddressId != 0
                && entityData.AddressId != existingEntity.AddressId)
            {
                existingEntity.AddressId = entityData.AddressId;
            }

            if (entityData.DocumentId != null
                && entityData.DocumentId != 0
                && entityData.DocumentId != existingEntity.DocumentId)
            {
                existingEntity.DocumentId = entityData.DocumentId;
            }

            if (entityData.OspTypeId != null
                && entityData.OspTypeId != 0
                && entityData.OspTypeId != existingEntity.OspTypeId)
            {
                existingEntity.OspTypeId = entityData.OspTypeId;
            }

            if (entityData.ExclusionDate != default(DateTime)
                && entityData.ExclusionDate != null
                && entityData.ExclusionDate != existingEntity.ExclusionDate)
            {
                existingEntity.ExclusionDate = entityData.ExclusionDate;
            }

            if (entityData.InclusionDate != default(DateTime)
                && entityData.InclusionDate != null
                && entityData.InclusionDate != existingEntity.InclusionDate)
            {
                existingEntity.ExclusionDate = entityData.InclusionDate;
            }

            if (entityData.OrgDocumentId != null
                && entityData.OrgDocumentId != 0
                && entityData.OrgDocumentId != existingEntity.OrgDocumentId)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.DateBeg != default(DateTime)
                && entityData.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (entityData.DateEnd != default(DateTime)
                && entityData.DateEnd != null
                && entityData.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            if (entityData.CommunicationId != null
                && entityData.CommunicationId != 0
                && entityData.CommunicationId != existingEntity.CommunicationId)
            {
                existingEntity.CommunicationId = entityData.CommunicationId;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (!entityData.ParentId.IsNullOrEmpty()
                && entityData.ParentId != existingEntity.ParentId)
            {
                existingEntity.ParentId = entityData.ParentId;
            }

            if (!entityData.f031_ermoId.IsNullOrEmpty()
                && entityData.f031_ermoId != existingEntity.f031_ermoId)
            {
                existingEntity.f031_ermoId = entityData.f031_ermoId;
            }

            if (entityData.f031_ermoParentId != null
                && entityData.f031_ermoParentId != existingEntity.f031_ermoParentId)
            {
                existingEntity.f031_ermoParentId = entityData.f031_ermoParentId;
            }

            if (entityData.DateBeginOms != null
                && entityData.DateBeginOms != default(DateTime)
                && entityData.DateBeginOms != existingEntity.DateBeginOms)
            {
                existingEntity.DateBeginOms = entityData.DateBeginOms;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
