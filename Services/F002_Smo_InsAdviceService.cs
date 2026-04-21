using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F002_Smo_InsAdviceService
    {
        public readonly F002_Smo_InsAdviceRepository _f002_Smo_InsAdviceRepository;

        public F002_Smo_InsAdviceService(F002_Smo_InsAdviceRepository f002_Smo_InsAdviceRepository)
        {
            _f002_Smo_InsAdviceRepository = f002_Smo_InsAdviceRepository;
        }

        public async Task<f002_smo_insAdvice> SaveF002_Smo_InsAdviceService(f002_smo_insAdvice entityData)
        {
            return await _f002_Smo_InsAdviceRepository.SaveData(entityData);
        }

        public async Task<f002_smo_insAdvice> GetEnitityByAttributes(f002_smo_insAdvice entityData)
        {
            return await _f002_Smo_InsAdviceRepository.GetEnitityByAttributes(entityData);
        }
    }
}
