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
    public class VidTypeService
    {
        private readonly VidTypeRepository _vidMoRepository;

        public VidTypeService(VidTypeRepository vidMoRepository)
        {
            _vidMoRepository = vidMoRepository;
        }

        public async Task<VidType> SaveVidMoObject(VidType vidMo)
        {
            return await _vidMoRepository.SaveData(vidMo);
        }

        public async Task<VidType> GetEnitityByAttributes(VidType vidMo)
        {
            return await _vidMoRepository.GetEnitityByAttributes(vidMo);
        }
    }
}
