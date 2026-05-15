using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class DistrictService
    {
        public readonly DistrictRepository _districtRepository;

        public DistrictService(DistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<District> SaveDistrictObject(District district)
        {
            return await _districtRepository.SaveData(district);
        }

        public async Task<District> GetEnitityByAttributes(District district)
        {
            return await _districtRepository.GetEnitityByAttributes(district);
        }
    }
}
