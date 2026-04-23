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
    public class OrganizationRepository : AbstractBaseRepository<Organization>, ISearchData<Organization>
    {
        private readonly ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Organization> GetEnitityByAttributes(Organization entityData)
        {
            IQueryable<Organization> organizationResult = _context.Organizations;

            Organization updatedOrg = null;
            if (entityData.OrgNameId != null && entityData.OrgNameId != 0)
            {
                organizationResult = organizationResult
                    .Where(c => c.OrgNameId == entityData.OrgNameId);

                Organization existingOrg = await organizationResult.FirstOrDefaultAsync();

                if (existingOrg != null)
                {
                    updatedOrg = await UpdateObject(existingOrg, entityData);
                }
            }

            //if (entityData.KfTf != null)
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.KfTf == entityData.KfTf);
            //}

            //if (!entityData.Kbk.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.Kbk == entityData.Kbk);
            //}

            //if (entityData.NoSmo != null)
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.NoSmo == entityData.NoSmo);
            //}

            //if (!entityData.OrgCode.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.OrgCode == entityData.OrgCode);
            //}

            //if (!entityData.Mcod.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.Mcod == entityData.Mcod);
            //}

            //if (!entityData.Okopf.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.Okopf == entityData.Okopf);
            //}

            //if (!entityData.NameE.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.NameE == entityData.NameE);
            //}

            //if (entityData.NalP != null && entityData.NalP != 0)
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.NalP == entityData.NalP);
            //}

            //if (!entityData.VedPri.IsNullOrEmpty())
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.VedPri == entityData.VedPri);
            //}

            //if (entityData.OrgTypeId != null && entityData.OrgTypeId != 0)
            //{
            //    organizationResult = organizationResult
            //        .Where(c => c.OrgTypeId == entityData.OrgTypeId);
            //}

            return updatedOrg;
        }

        public async Task<Organization> UpdateObject(Organization existingEntity, Organization entityData)
        {
            if (entityData.KfTf != null
                && entityData.KfTf != existingEntity.KfTf)
            {
                existingEntity.KfTf = entityData.KfTf;
            }

            if (!entityData.Kbk.IsNullOrEmpty()
                && entityData.Kbk != existingEntity.Kbk)
            {
                existingEntity.Kbk = entityData.Kbk;
            }

            if (entityData.NoSmo != null
                && entityData.NoSmo != existingEntity.NoSmo)
            {
                existingEntity.NoSmo = entityData.NoSmo;
            }

            if (!entityData.OrgCode.IsNullOrEmpty()
                && entityData.OrgCode != existingEntity.OrgCode)
            {
                existingEntity.OrgCode = entityData.OrgCode;
            }

            if (!entityData.Mcod.IsNullOrEmpty()
                && entityData.Mcod != existingEntity.Mcod)
            {
                existingEntity.Mcod = entityData.Mcod;
            }

            if (!entityData.Okopf.IsNullOrEmpty()
                && entityData.Okopf != existingEntity.Okopf)
            {
                existingEntity.Okopf = entityData.Okopf;
            }

            //if (!entityData.NameE.IsNullOrEmpty())
            //{
            //    existingEntity.NameE = entityData.NameE;
            //}

            //if (entityData.NalP != null && entityData.NalP != 0)
            //{
            //    existingEntity.NalP = entityData.NalP;
            //}

            if (!entityData.VedPri.IsNullOrEmpty()
                && entityData.VedPri != existingEntity.VedPri)
            {
                existingEntity.VedPri = entityData.VedPri;
            }

            if (entityData.OrgTypeId != null
                && entityData.OrgTypeId != 0
                && entityData.OrgTypeId != existingEntity.OrgTypeId)
            {
                existingEntity.OrgTypeId = entityData.OrgTypeId;
            }

            // Асинхронно сохраняем изменения
            _context.Update(existingEntity);
            await _context.SaveChangesAsync();  // Ключевой момент!

            return existingEntity;
        }

        /// <summary>
        /// Найти организацию по Mcod
        /// </summary>
        /// <param name="Mcod"></param>
        /// <returns>Экземпляр найденой организации</returns>
        public async Task<Organization> FindOrganizationByMcod(string Mcod)
        {
            return await _context.Organizations
                .Where(c => c.Mcod == Mcod)
                .FirstOrDefaultAsync();
        }
    }
}
