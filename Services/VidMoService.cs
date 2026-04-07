using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class VidMoService
    {
        private readonly VidMoRepository _vidMoRepository;

        public VidMoService(VidMoRepository vidMoRepository)
        {
            _vidMoRepository = vidMoRepository;
        }

        public async Task<VidMo> SaveVidMoObject(VidMo vidMo)
        {
            return await _vidMoRepository.SaveData(vidMo);
        }

        public async Task<VidMo> GetEnitityByAttributes(VidMo vidMo)
        {
            return await _vidMoRepository.GetEnitityByAttributes(vidMo);
        }
    }
}
