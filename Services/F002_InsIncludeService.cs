using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F002_InsIncludeService
    {
        private readonly F002_InsIncludeRepository _insIncludeRepository;

        public F002_InsIncludeService(F002_InsIncludeRepository insIncludeRepository)
        {
            _insIncludeRepository = insIncludeRepository;
        }

        public async Task<f002_InsInclude> GetEnitityByAttributes(f002_InsInclude entityData)
        {
            return await _insIncludeRepository.GetEnitityByAttributes(entityData);
        }

        public async Task<f002_InsInclude> SaveInsIncludeObject(f002_InsInclude entityData)
        {
            return await _insIncludeRepository.SaveData(entityData);
        }
    }
}
