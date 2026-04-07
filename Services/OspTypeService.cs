using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OspTypeService
    {
        private readonly OspTypeRepository _ospTypeRepository;

        public OspTypeService(OspTypeRepository ospTypeRepository)
        {
            _ospTypeRepository = ospTypeRepository;
        }

        public async Task<OspType> SaveOspTypeObject(OspType ospType)
        {
            return await _ospTypeRepository.SaveData(ospType);
        }

        public async Task<OspType> GetEnitityByAttributes(OspType ospType)
        {
            return await _ospTypeRepository.GetEnitityByAttributes(ospType);
        }
    }
}
