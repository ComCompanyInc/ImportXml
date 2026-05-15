using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class StatTypeService
    {
        private readonly StatTypeRepository _statTypeRepository;

        public StatTypeService(StatTypeRepository statTypeRepository)
        {
            _statTypeRepository = statTypeRepository;
        }

        public async Task<StatType> SaveStatTypeObject(StatType entityData)
        {
            return await _statTypeRepository.SaveData(entityData);
        }

        public async Task<StatType> GetEnitityByAttributes(StatType entityData)
        {
            return await _statTypeRepository.GetEnitityByAttributes(entityData);
        }
    }
}
