using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class LicenseService
    {
        private readonly LicenseRepository _licenseRepository;

        public LicenseService(LicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<Models.License> SaveLicenseObject(Models.License entityData)
        {
            return await _licenseRepository.SaveData(entityData);
        }

        public async Task<Models.License> GetEnitityByAttributes(Models.License entityData)
        {
            return await _licenseRepository.GetEnitityByAttributes(entityData);
        }
    }
}
