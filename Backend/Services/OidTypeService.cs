using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OidTypeService
    {
        private readonly OidTypeRepository _oidTypeRepository;

        public OidTypeService(OidTypeRepository ospTypeRepository)
        {
            _oidTypeRepository = ospTypeRepository;
        }

        public async Task<OidType> SaveOidTypeObject(OidType oidType)
        {
            return await _oidTypeRepository.SaveData(oidType);
        }

        public async Task<OidType> GetEnitityByAttributes(OidType oidType)
        {
            return await _oidTypeRepository.GetEnitityByAttributes(oidType);
        }
    }
}
