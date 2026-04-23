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
    public class F002_SmoEmpRepository : AbstractBaseRepository<f002_smoEmp>, ISearchData<f002_smoEmp>
    {
        private readonly ApplicationDbContext _context;

        public F002_SmoEmpRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<f002_smoEmp> GetEnitityByAttributes(f002_smoEmp entityData)
        {
            IQueryable<f002_smoEmp> f002_smoEmpResult = _context.F002_SmoEmps;

            f002_smoEmp updatedF002_SmoEmp = null;
            if (!entityData.SmoCod.IsNullOrEmpty())
            {
                f002_smoEmpResult = f002_smoEmpResult
                    .Where(c => c.SmoCod == entityData.SmoCod);

                f002_smoEmp existingF002_SmoEmp = await f002_smoEmpResult.FirstOrDefaultAsync();
                if (existingF002_SmoEmp != null)
                {
                    updatedF002_SmoEmp = await UpdateObject(existingF002_SmoEmp, entityData);
                }
            }

            return updatedF002_SmoEmp;
        }

        public async Task<f002_smoEmp> UpdateObject(f002_smoEmp existingEntity, f002_smoEmp entityData)
        {
            if (entityData.AddressId != null
                && entityData.AddressId != 0
                && entityData.AddressId != existingEntity.AddressId)
            {
                existingEntity.AddressId = entityData.AddressId;
            }

            if (entityData.OrganizationId != null
                && entityData.OrganizationId != 0
                && entityData.OrganizationId != existingEntity.OrganizationId)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.DocumentId != null
                && entityData.DocumentId != 0
                && entityData.DocumentId != existingEntity.DocumentId)
            {
                existingEntity.DocumentId = entityData.DocumentId;
            }

            if (entityData.CommunicationId != null
                && entityData.CommunicationId != 0
                && entityData.CommunicationId != existingEntity.CommunicationId)
            {
                existingEntity.CommunicationId = entityData.CommunicationId;
            }

            if (entityData.PersonId != null
                && entityData.PersonId != 0
                && entityData.PersonId != existingEntity.PersonId)
            {
                existingEntity.PersonId = entityData.PersonId;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
