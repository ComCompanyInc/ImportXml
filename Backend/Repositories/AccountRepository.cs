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
    public class AccountRepository : AbstractBaseRepository<Account>, ISearchData<Account>
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<object>> GetDataBySearchFilter(Account FilterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetEnitityByAttributes(Account entityData)
        {
            IQueryable<Account> accountResult = _context.Accounts;

            Account updatedAccount = null;
            if (!entityData.Rs.IsNullOrEmpty()
                && !entityData.Bank.IsNullOrEmpty())
            {
                accountResult = accountResult
                    .Where(c => c.Rs == entityData.Rs
                            && c.Bank == entityData.Bank);

                Account existingAccount = await accountResult.FirstOrDefaultAsync();
                if (existingAccount != null)
                {
                    updatedAccount = await UpdateObject(existingAccount, entityData);
                }
            }

            return updatedAccount;
        }

        public async Task<Account> UpdateObject(Account existingEntity, Account entityData)
        {
            if (existingEntity.Name.IsNullOrEmpty()
                && existingEntity.Name != existingEntity.Name)
            {
                existingEntity.Name = entityData.Name;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }
    }
}
