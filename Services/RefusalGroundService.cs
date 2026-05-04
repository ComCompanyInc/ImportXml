using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class RefusalGroundService
    {
        public RefusalGroundRepository _refusalGroundRepository;

        public RefusalGroundService(RefusalGroundRepository refusalGroundRepository)
        {
            _refusalGroundRepository = refusalGroundRepository;
        }

        public async Task<RefusalGround> SaveRefusalGroundObject(RefusalGround refusalGround)
        {
            return await _refusalGroundRepository.SaveData(refusalGround);
        }

        public async Task<RefusalGround> GetEnitityByAttributes(RefusalGround refusalGround)
        {
            return await _refusalGroundRepository.GetEnitityByAttributes(refusalGround);
        }
    }
}
