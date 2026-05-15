using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OrgNameService
    {
        private readonly OrgNameRepository _orgNameRepository;

        public OrgNameService(OrgNameRepository orgNameRepository)
        {
            _orgNameRepository = orgNameRepository;
        }

        public async Task<OrgName> SaveOrgNameObject(OrgName orgName)
        {
            return await _orgNameRepository.SaveData(orgName);
        }

        public async Task<OrgName> GetEnitityByAttributes(OrgName orgName)
        {
            return await _orgNameRepository.GetEnitityByAttributes(orgName);
        }
    }
}
