using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class BaseDataService
    {
        private readonly BaseDataRepository _baseDataRepository;

        public BaseDataService(BaseDataRepository baseDataRepository)
        {
            _baseDataRepository = baseDataRepository;
        }

        public async Task<BaseData> SaveBaseDataObject(BaseData baseData) {
            return await _baseDataRepository.SaveData(baseData);
        }
    }
}
