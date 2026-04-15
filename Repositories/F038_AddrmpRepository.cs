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
    public class F038_AddrmpRepository : AbstractBaseRepository<f038_addrmp>, ISearchData<f038_addrmp>
    {
        private readonly ApplicationDbContext _context;

        public F038_AddrmpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f038_addrmp> GetEnitityByAttributes(f038_addrmp entityData)
        {
            IQueryable<f038_addrmp> f038_addrmpResult = _context.F038_Addrmps;

            if (!entityData.Id.IsNullOrEmpty())
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.Id == entityData.Id);
            }

            if (!entityData.F032_TrmoId.IsNullOrEmpty())
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.F032_TrmoId == entityData.F032_TrmoId);
            }

            if (!entityData.F033_SpmoId.IsNullOrEmpty())
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.F033_SpmoId == entityData.F033_SpmoId);
            }

            if (!entityData.LicenseNum.IsNullOrEmpty())
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.LicenseNum == entityData.LicenseNum);
            }

            if (entityData.AddressId != null && entityData.AddressId != 0)
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.AddressId == entityData.AddressId);
            }

            if (entityData.DateBeg != null && entityData.DateBeg != default(DateTime))
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.DateBeg == entityData.DateBeg);
            }

            if (entityData.DateEnd != null && entityData.DateEnd != default(DateTime))
            {
                f038_addrmpResult = f038_addrmpResult
                    .Where(c => c.DateEnd == entityData.DateEnd);
            }

            return await f038_addrmpResult.FirstOrDefaultAsync();
        }
    }
}
