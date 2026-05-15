using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class ExpTypeService
    {
        private readonly ExpTypeRepository _expTypeRepository;

        public ExpTypeService(ExpTypeRepository expTypeRepository)
        {
            _expTypeRepository = expTypeRepository;
        }

        public async Task<ExpType> SaveExpTypeObject(ExpType entityData)
        {
            return await _expTypeRepository.SaveData(entityData);
        }

        public async Task<ExpType> GetEnitityByAttributes(ExpType entityData)
        {
            return await _expTypeRepository.GetEnitityByAttributes(entityData);
        }
    }
}
