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
    public class CommunicationRepository : AbstractBaseRepository<Communication>, ISearchData<Communication>
    {
        private readonly ApplicationDbContext _context;

        public CommunicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Communication> GetEnitityByAttributes(
            Communication communicationData
        )
        {
            IQueryable<Communication> communication = _context.Communications; //IQueryable<> - сохраняет состояние запросов (where и тд) в отличае от DbSet

            Communication updatedCommunication = null;
            if (!communicationData.Phone.IsNullOrEmpty())
            {
                communication = communication
                    .Where(c => c.Phone == communicationData.Phone);

                Communication existingCommunication = await communication.FirstOrDefaultAsync();
                if (existingCommunication != null)
                {
                    updatedCommunication = await UpdateObject(existingCommunication, communicationData);
                }
            }

            //if (!communicationData.Fax.IsNullOrEmpty())
            //{
            //    communication = communication
            //        .Where(c => c.Fax == communicationData.Fax);
            //}

            //if (!communicationData.Email.IsNullOrEmpty())
            //{
            //    communication = communication
            //        .Where(c => c.Email == communicationData.Email);
            //}

            //if (!communicationData.HotLine.IsNullOrEmpty())
            //{
            //    communication = communication
            //        .Where(c => c.HotLine == communicationData.HotLine);
            //}

            //if (!communicationData.Site.IsNullOrEmpty())
            //{
            //    communication = communication
            //        .Where(c => c.Site == communicationData.Site);
            //}

            return updatedCommunication;
        }

        public async Task<Communication> UpdateObject(Communication existingEntity, Communication entityData)
        {

            if (!entityData.Fax.IsNullOrEmpty()
                && entityData.Fax != existingEntity.Fax)
            {
                existingEntity.Fax = entityData.Fax;
            }

            if (!entityData.Email.IsNullOrEmpty()
                && entityData.Email != existingEntity.Email)
            {
                existingEntity.Email = entityData.Email;
            }

            if (!entityData.HotLine.IsNullOrEmpty()
                && entityData.HotLine != existingEntity.HotLine)
            {
                existingEntity.HotLine = entityData.HotLine;
            }

            if (!entityData.Site.IsNullOrEmpty()
                && entityData.Site != existingEntity.Site)
            {
                existingEntity.Site = entityData.Site;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
