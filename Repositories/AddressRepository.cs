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
    public class AddressRepository : AbstractBaseRepository<Address>, ISearchData<Address>
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Address> GetEnitityByAttributes(Address entityData)
        {
            IQueryable<Address> addressesResult = _context.Addresses;

            if (!entityData.Name.IsNullOrEmpty())
            {
                addressesResult = addressesResult
                    .Where(c => c.Name == entityData.Name);
            }

            if (!entityData.Index.IsNullOrEmpty())
            {
                addressesResult = addressesResult
                    .Where(c => c.Index == entityData.Index);
            }

            if (!entityData.Okato.IsNullOrEmpty())
            {
                addressesResult = addressesResult
                    .Where(c => c.Okato == entityData.Okato);
            }

            if (!entityData.AddressCode.IsNullOrEmpty())
            {
                addressesResult = addressesResult
                    .Where(c => c.AddressCode == entityData.AddressCode);
            }

            if (entityData.DistrictId != null)
            {
                addressesResult = addressesResult
                    .Where(c => c.DistrictId == entityData.DistrictId);
            }

            if (entityData.Oktmo != null)
            {
                addressesResult = addressesResult
                    .Where(c => c.Oktmo == entityData.Oktmo);
            }

            if (entityData.Oktmo != null)
            {
                addressesResult = addressesResult
                    .Where(c => c.Oktmo == entityData.Oktmo);
            }

            return await addressesResult.FirstOrDefaultAsync();
        }
    }
}
