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

            if (!entityData.Name.IsNullOrEmpty()) {
                organizationResult = organizationResult
                    .Where(c => c.Name == entityData.Name);
            }

            if (!entityData.ShortName.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.ShortName == entityData.ShortName);
            }

            if (entityData.KfTf != null)
            {
                organizationResult = organizationResult
                    .Where(c => c.KfTf == entityData.KfTf);
            }

            if (!entityData.Kbk.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.Kbk == entityData.Kbk);
            }

            if (entityData.NoSmo != null)
            {
                organizationResult = organizationResult
                    .Where(c => c.NoSmo == entityData.NoSmo);
            }

            if (!entityData.OrgCode.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.OrgCode == entityData.OrgCode);
            }

            if (!entityData.Mcod.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.Mcod == entityData.Mcod);
            }

            if (!entityData.Okopf.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.Okopf == entityData.Okopf);
            }

            if (!entityData.NameE.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.NameE == entityData.NameE);
            }

            if (entityData.NalP != entityData.NalP)
            {
                organizationResult = organizationResult
                    .Where(c => c.NalP == entityData.NalP);
            }

            if (!entityData.VedPri.IsNullOrEmpty())
            {
                organizationResult = organizationResult
                    .Where(c => c.VedPri == entityData.VedPri);
            }

            if (entityData.OrgTypeId != null)
            {
                organizationResult = organizationResult
                    .Where(c => c.OrgTypeId == entityData.OrgTypeId);
            }

            return await organizationResult.FirstOrDefaultAsync();
        }
    }
}
