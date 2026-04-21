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
    public class F002_Smo_InsAdviceRepository : AbstractBaseRepository<f002_smo_insAdvice>, ISearchData<f002_smo_insAdvice>
    {
        private readonly ApplicationDbContext _context;

        public F002_Smo_InsAdviceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f002_smo_insAdvice> GetEnitityByAttributes(f002_smo_insAdvice entityData)
        {
            IQueryable<f002_smo_insAdvice> f002_smo_insAdviceResult = _context.f002_smo_insAdvices;

            if (!entityData.YearWork.IsNullOrEmpty())
            {
                f002_smo_insAdviceResult = f002_smo_insAdviceResult
                    .Where(c => c.YearWork == entityData.YearWork);
            }

            if (entityData.Duved != null && entityData.Duved != default(DateTime))
            {
                f002_smo_insAdviceResult = f002_smo_insAdviceResult
                    .Where(c => c.Duved == entityData.Duved);
            }

            if (entityData.KolZl != null)
            {
                f002_smo_insAdviceResult = f002_smo_insAdviceResult
                    .Where(c => c.KolZl == entityData.KolZl);
            }

            if (entityData.DEdit != null && entityData.DEdit != default(DateTime))
            {
                f002_smo_insAdviceResult = f002_smo_insAdviceResult
                    .Where(c => c.DEdit == entityData.DEdit);
            }

            return await f002_smo_insAdviceResult.FirstOrDefaultAsync();
        }

        public Task<f002_smo_insAdvice> UpdateObject(f002_smo_insAdvice existingEntity, f002_smo_insAdvice entityData)
        {
            throw new NotImplementedException();
        }
    }
}
