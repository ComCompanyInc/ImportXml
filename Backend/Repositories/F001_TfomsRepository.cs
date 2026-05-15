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
    public class F001_TfomsRepository : AbstractBaseRepository<f001_tfoms>, ISearchData<f001_tfoms>
    {
        private readonly ApplicationDbContext _context;

        public F001_TfomsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<f001_tfoms>> GetDataBySearchFilter(f001_tfoms FilterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<f001_tfoms> GetEnitityByAttributes(f001_tfoms entityData)
        {
            IQueryable<f001_tfoms> f001_TfomsResult = _context.F001_Tfoms;

            f001_tfoms updatedF001_Tfoms = null;
            if (entityData.F010_Subecti != null
                && !entityData.F010_Subecti.CodeTf.IsNullOrEmpty())
            {
                f001_TfomsResult = f001_TfomsResult
                    .Where(c => c.F010_Subecti.CodeTf == entityData.F010_Subecti.CodeTf);

                f001_tfoms existingF001_tfoms = await f001_TfomsResult.FirstOrDefaultAsync();
                if (existingF001_tfoms != null)
                {
                    updatedF001_Tfoms = await UpdateObject(existingF001_tfoms, entityData);
                }
            }

            return updatedF001_Tfoms;
        }

        public async Task<f001_tfoms> UpdateObject(f001_tfoms existingEntity, f001_tfoms entityData)
        {
            if (entityData.DEdit != null
                && entityData.DEdit != default(DateTime)
                && entityData.DEdit != existingEntity.DEdit)
            {
                existingEntity.DEdit = entityData.DEdit;
            }

            if (entityData.DEnd != null
                && entityData.DEnd != default(DateTime)
                && entityData.DEnd != existingEntity.DEnd)
            {
                existingEntity.DEnd = entityData.DEnd;
            }

            if (entityData.DBegin != null
                && entityData.DBegin != default(DateTime)
                && entityData.DBegin != existingEntity.DBegin)
            {
                existingEntity.DBegin = entityData.DBegin;
            }

            if (entityData.NoSmo != null
                && entityData.NoSmo != existingEntity.NoSmo)
            {
                existingEntity.NoSmo = entityData.NoSmo;
            }

            if (!entityData.Bic.IsNullOrEmpty()
                && entityData.Bic != existingEntity.Bic)
            {
                existingEntity.Bic = entityData.Bic;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
