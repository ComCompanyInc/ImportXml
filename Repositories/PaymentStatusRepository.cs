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
    public class PaymentStatusRepository : AbstractBaseRepository<PaymentStatus>, ISearchData<PaymentStatus>
    {
        private readonly ApplicationDbContext _context;

        public PaymentStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaymentStatus> GetEnitityByAttributes(PaymentStatus entityData)
        {
            IQueryable<PaymentStatus> paymentStatusResult = _context.PaymentStatuses;

            if (!entityData.StatusName.IsNullOrEmpty())
            {
                paymentStatusResult = paymentStatusResult
                    .Where(c => c.StatusName == entityData.StatusName);
            }

            return await paymentStatusResult.FirstOrDefaultAsync();
        }

        public Task<PaymentStatus> UpdateObject(PaymentStatus existingEntity, PaymentStatus entityData)
        {
            throw new NotImplementedException();
        }
    }
}
