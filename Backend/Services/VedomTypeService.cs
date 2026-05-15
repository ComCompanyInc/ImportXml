using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class VedomTypeService
    {
        private readonly VedomTypeRepository _vedomTypeRepository;

        public VedomTypeService(
            VedomTypeRepository vedomTypeRepository
        )
        {
            _vedomTypeRepository = vedomTypeRepository;
        }

        public async Task<VedomType> GetEnitityByAttributes(VedomType entityData)
        {
            return await _vedomTypeRepository.GetEnitityByAttributes(entityData);
        }

        public async Task<VedomType> SaveVedomTypeObject(VedomType entityData)
        {
            return await _vedomTypeRepository.SaveData(entityData);
        }
    }
}
