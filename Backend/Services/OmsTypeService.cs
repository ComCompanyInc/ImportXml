using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OmsTypeService
    {
        public OmsTypeRepository _omsTypeRepository;

        public OmsTypeService(OmsTypeRepository omsTypeRepository)
        {
            _omsTypeRepository = omsTypeRepository;
        }

        public async Task<OmsType> SaveOmsTypeObject(OmsType entityData)
        {
            return await _omsTypeRepository.SaveData(entityData);
        }

        public async Task<OmsType> GetEnitityByAttributes(OmsType entityData)
        {
            return await _omsTypeRepository.GetEnitityByAttributes(entityData);
        }
    }
}
