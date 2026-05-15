using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OrgTypeService
    {
        private readonly OrgTypeRepository _orgTypeRepository;

        public OrgTypeService(OrgTypeRepository orgTypeRepository)
        {
            _orgTypeRepository = orgTypeRepository;
        }

        public async Task<OrgType> SaveOrgTypeObject(OrgType orgType)
        {
            return await _orgTypeRepository.SaveData(orgType);
        }

        public async Task<OrgType> GetEnitityByAttributes(OrgType orgType)
        {
            return await _orgTypeRepository.GetEnitityByAttributes(orgType);
        }
    }
}
