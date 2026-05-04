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
    public class F014_OplOtkRepository : AbstractBaseRepository<f014_OplOtk>, ISearchData<f014_OplOtk>
    {
        public ApplicationDbContext _context;

        public F014_OplOtkRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f014_OplOtk> GetEnitityByAttributes(f014_OplOtk entityData)
        {
            IQueryable<f014_OplOtk> f014_OplOtkResult = _context.F014_OplOtks;

            f014_OplOtk updatedF014_OplOtk = null;
            if (entityData.ErrorCode != null
                && entityData.ErrorCode != 0)
            {
                if (entityData.DateBeg != null
                    && entityData.DateBeg != default(DateTime))
                {
                    f014_OplOtkResult = f014_OplOtkResult
                        .Where(c => c.ErrorCode == entityData.ErrorCode
                                && c.DateBeg == entityData.DateBeg);

                    f014_OplOtk existingF014_OplOtk = await f014_OplOtkResult.FirstOrDefaultAsync();
                    if (existingF014_OplOtk != null)
                    {
                        updatedF014_OplOtk = await UpdateObject(existingF014_OplOtk, entityData);
                    }
                }
            }

            return updatedF014_OplOtk;
        }

        public async Task<f014_OplOtk> UpdateObject(f014_OplOtk existingEntity, f014_OplOtk entityData)
        {
            if (entityData.f006_VidExpVidId != null
                && entityData.f006_VidExpVidId != 0
                && entityData.f006_VidExpVidId != existingEntity.f006_VidExpVidId)
            {
                existingEntity.f006_VidExpVidId = entityData.f006_VidExpVidId;
            }

            if (!entityData.RefusalReason.IsNullOrEmpty()
                && entityData.RefusalReason != existingEntity.RefusalReason)
            {
                existingEntity.RefusalReason = entityData.RefusalReason;
            }

            if (entityData.RefusalGroundId != null
                && entityData.RefusalGroundId != 0
                && entityData.RefusalGroundId != existingEntity.RefusalGroundId)
            {
                existingEntity.RefusalGroundId = entityData.RefusalGroundId;
            }

            if (!entityData.OfficialComment.IsNullOrEmpty()
                && entityData.OfficialComment != existingEntity.OfficialComment)
            {
                existingEntity.OfficialComment = entityData.OfficialComment;
            }

            if (entityData.CoefNonPay != null
                && entityData.CoefNonPay != 0
                && entityData.CoefNonPay != existingEntity.CoefNonPay)
            {
                existingEntity.CoefNonPay = entityData.CoefNonPay;
            }

            if (entityData.CoefNonPay != null
                && entityData.CoefNonPay != 0
                && entityData.CoefNonPay != existingEntity.CoefNonPay)
            {
                existingEntity.CoefNonPay = entityData.CoefNonPay;
            }

            if (entityData.CoefForfeit != null
                && entityData.CoefForfeit != 0
                && entityData.CoefForfeit != existingEntity.CoefForfeit)
            {
                existingEntity.CoefForfeit = entityData.CoefForfeit;
            }

            if (entityData.CodePG.IsNullOrEmpty()
                && entityData.CodePG != existingEntity.CodePG)
            {
                existingEntity.CodePG = entityData.CodePG;
            }

            if (entityData.DateEnd != null
                && entityData.DateEnd != default(DateTime)
                && entityData.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
