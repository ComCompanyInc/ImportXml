using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> SaveAccountObject(Account entityData)
        {
            return await _accountRepository.SaveData(entityData);
        }

        public async Task<Account> GetEnitityByAttributes(Account entityData)
        {
            return await _accountRepository.GetEnitityByAttributes(entityData);
        }
    }
}
