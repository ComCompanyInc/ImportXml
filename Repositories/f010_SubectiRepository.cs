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
    public class f010_SubectiRepository : AbstractBaseRepository<f010_Subecti>, ISearchData<f010_Subecti>
    {
        private readonly ApplicationDbContext _context;

        public f010_SubectiRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f010_Subecti> GetEnitityByAttributes(f010_Subecti entityData)
        {
            IQueryable<f010_Subecti> f010_SubectsResult = _context.F010_Subects;

            f010_Subecti updatedF010_Subecti = null;
            if (!entityData.CodeTf.IsNullOrEmpty()) // CodeTf - здесь часть уникальной записи
            {
                if (!entityData.Subject.Okato.IsNullOrEmpty()) // okato - здесь часть уникальной записи
                {
                    f010_Subecti existingF010_Subecti = await f010_SubectsResult
                        .Where(c => c.CodeTf == entityData.CodeTf
                            && c.Subject.Okato == entityData.Subject.Okato)
                        .FirstOrDefaultAsync();

                    if (existingF010_Subecti != null)
                    {
                        updatedF010_Subecti = await UpdateObject(existingF010_Subecti, entityData);
                    }
                }
            }

            return updatedF010_Subecti;
        }

        public async Task<f010_Subecti> UpdateObject(f010_Subecti existingEntity, f010_Subecti entityData)
        {
            if (!entityData.CodeTf.IsNullOrEmpty()
                && entityData.CodeTf != existingEntity.CodeTf)
            {
                existingEntity.CodeTf = entityData.CodeTf;
            }

            if (entityData.SubjectId != null
                && entityData.SubjectId != 0
                && entityData.SubjectId != existingEntity.SubjectId)
            {
                existingEntity.SubjectId = entityData.SubjectId;
            }

            if (entityData.DateBeg != null
                && entityData.DateBeg != default(DateTime)
                && entityData.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = existingEntity.DateBeg;
            }

            if (entityData.DateEnd != null
                && entityData.DateEnd != default(DateTime)
                && entityData.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = existingEntity.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
