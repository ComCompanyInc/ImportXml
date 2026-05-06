using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F019_PersAccOrg : AbstractBaseRepository<f019_PersAccOrg>, ISearchData<f019_PersAccOrg>
    {
        private readonly ApplicationDbContext _context;

        public F019_PersAccOrg(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /*
         public Task<f019_PersAccOrg> GetEnitityByAttributes(f019_PersAccOrg entityData)
        {
            if (entityData.Organization != null)
            {
            
            }
        }
         */

        public Task<f019_PersAccOrg> GetEnitityByAttributes(f019_PersAccOrg entityData)
        {
            throw new NotImplementedException();
        }

        public Task<f019_PersAccOrg> UpdateObject(f019_PersAccOrg existingEntity, f019_PersAccOrg entityData)
        {
            throw new NotImplementedException();
        }
    }
}
