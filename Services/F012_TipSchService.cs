using BackendApp.Dto;
using BackendApp.Dto.f011_tipdoc;
using BackendApp.Dto.f012_tipsch;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F012_TipSchService
    {
        private readonly F012_TipSchRepository _f012_TipRepository;

        private readonly BaseDataService _baseDataService;

        public F012_TipSchService(
            F012_TipSchRepository f012_TipRepository,
            BaseDataService baseDataService
        )
        {
            _f012_TipRepository = f012_TipRepository;

            _baseDataService = baseDataService;
        }

        public async Task<bool> SaveDataFromF12(DocumentDto<F12DataDto> dataContainer)
        {
            BaseData baseData = new BaseData
            {
                Type = dataContainer.BaseData.Type,
                Version = dataContainer.BaseData.Version,
                Date = DateTime.ParseExact(dataContainer.BaseData.Date, "dd.MM.yyyy", null),
            };

            long baseDataId;

            BaseData existingBaseData = await _baseDataService.GetEnitityByAttributes(baseData);
            if (existingBaseData != null)
            {
                baseDataId = existingBaseData.Id;
            }
            else
            {
                baseDataId = (await _baseDataService.SaveBaseDataObject(baseData)).Id;
            }

            foreach (F12DataDto item in dataContainer.ZapList)
            {
                f012_TipSch f012_TipSch = new f012_TipSch
                {
                    SchId = item.SchId,
                    BaseDataId = baseDataId,
                    Name = item.Name,
                    ShortName = item.ShortName,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                string f012_TipSchId;

                f012_TipSch existingF012_TipSch = await this.GetEnitityByAttributes(f012_TipSch);
                if (existingF012_TipSch != null)
                {
                    f012_TipSchId = existingF012_TipSch.SchId;
                }
                else
                {
                    f012_TipSchId = (await this.SaveF012_TipSchObject(f012_TipSch)).SchId;
                }
            }

            return true;
        }

        public async Task<f012_TipSch> SaveF012_TipSchObject(f012_TipSch entityData)
        {
            return await _f012_TipRepository.SaveData(entityData);
        }

        public async Task<f012_TipSch> GetEnitityByAttributes(f012_TipSch entityData)
        {
            return await _f012_TipRepository.GetEnitityByAttributes(entityData);
        }
    }
}
