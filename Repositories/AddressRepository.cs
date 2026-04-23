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

            Address updatedAddress = null;
            if (!entityData.Name.IsNullOrEmpty())
            {
                addressesResult = addressesResult
                    .Where(c => c.Name == entityData.Name);

                Address existingAddress = await addressesResult.FirstOrDefaultAsync();
                if (existingAddress != null)
                {
                    updatedAddress = await UpdateObject(existingAddress, entityData);
                }
            }

            //if (!entityData.Index.IsNullOrEmpty())
            //{
            //    addressesResult = addressesResult
            //        .Where(c => c.Index == entityData.Index);
            //}

            //if (!entityData.Okato.IsNullOrEmpty())
            //{
            //    addressesResult = addressesResult
            //        .Where(c => c.Okato == entityData.Okato);
            //}

            //if (!entityData.AddressCode.IsNullOrEmpty())
            //{
            //    addressesResult = addressesResult
            //        .Where(c => c.AddressCode == entityData.AddressCode);
            //}

            //if (entityData.DistrictId != null && entityData.DistrictId != 0)
            //{
            //    addressesResult = addressesResult
            //        .Where(c => c.DistrictId == entityData.DistrictId);
            //}

            //if (entityData.Oktmo != null)
            //{
            //    addressesResult = addressesResult
            //        .Where(c => c.Oktmo == entityData.Oktmo);
            //}

            return updatedAddress;
        }

        public async Task<Address> UpdateObject(Address existingEntity, Address entityData)
        {
            if (!entityData.Index.IsNullOrEmpty()
                && entityData.Index != existingEntity.Index)
            {
                existingEntity.Index = entityData.Index;
            }

            if (!entityData.Okato.IsNullOrEmpty()
                && entityData.Okato != existingEntity.Okato)
            {
                existingEntity.Okato = entityData.Okato;
            }

            if (!entityData.AddressCode.IsNullOrEmpty()
                && entityData.AddressCode != existingEntity.AddressCode)
            {
                existingEntity.AddressCode = entityData.AddressCode;
            }

            if (entityData.DistrictId != null
                && entityData.DistrictId != 0
                && entityData.DistrictId != existingEntity.DistrictId)
            {
                existingEntity.DistrictId = entityData.DistrictId;
            }

            if (entityData.Oktmo != null
                && entityData.Oktmo != existingEntity.Oktmo)
            {
                existingEntity.Oktmo = entityData.Oktmo;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
