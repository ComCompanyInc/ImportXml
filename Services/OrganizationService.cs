using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OrganizationService
    {
        private readonly OrganizationRepository _organizationRepository;

        public OrganizationService(OrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Organization> SaveOrganizationObject(Organization organization)
        {
            return await _organizationRepository.SaveData(organization);
        }

        public async Task<Organization> GetEnitityByAttributes(Organization organization)
        {
            return await _organizationRepository.GetEnitityByAttributes(organization);
        }
    }
}
