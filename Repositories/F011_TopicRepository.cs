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
    public class F011_TopicRepository : AbstractBaseRepository<f011_Tipdoc>, ISearchData<f011_Tipdoc>
    {
        private readonly ApplicationDbContext _context; 

        public F011_TopicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f011_Tipdoc> GetEnitityByAttributes(f011_Tipdoc entityData)
        {
            IQueryable<f011_Tipdoc> f011_TipdocResult = _context.F011_Tipdocs;

            f011_Tipdoc updatedF011_TipDocument = null;
            if (entityData.F008_TipOms != null
                && entityData.F008_TipOms.DocId != null
                && entityData.F008_TipOms.DocId != 0)
            {
                f011_TipdocResult = f011_TipdocResult
                    .Where(c => c.F008_TipOms.DocId == entityData.F008_TipOms.DocId);
            
                f011_Tipdoc existingF11_Tipdocument = await f011_TipdocResult.FirstOrDefaultAsync();

                if (existingF11_Tipdocument != null)
                {
                    updatedF011_TipDocument = await UpdateObject(existingF11_Tipdocument, entityData);
                }
            }

            return updatedF011_TipDocument;
        }

        public async Task<f011_Tipdoc> UpdateObject(f011_Tipdoc existingEntity, f011_Tipdoc entityData)
        {
            if (!entityData.DocSer.IsNullOrEmpty()
                && entityData.DocSer != existingEntity.DocSer)
            {
                existingEntity.DocSer = entityData.DocSer;
            }

            if (!entityData.DocNum.IsNullOrEmpty()
                && entityData.DocNum != existingEntity.DocNum)
            {
                existingEntity.DocNum = entityData.DocNum;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
