using BackendApp.Dto;
using BackendApp.Dto.f008_TipOms;
using BackendApp.Dto.F009_StatZl;
using BackendApp.Dto.f031_ermos;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F009_StatZlService
    {
        private readonly F009_StatZlRepository _f009_StatZlRepository;

        private readonly BaseDataService _baseDataService;
        private readonly StatTypeService _statTypeService;

        public F009_StatZlService(
            F009_StatZlRepository f009_StatZlRepository,
            BaseDataService baseDataService,
            StatTypeService statTypeService
        )
        {
            _f009_StatZlRepository = f009_StatZlRepository;

            _baseDataService = baseDataService;
            _statTypeService = statTypeService;
        }

        public async Task<bool> SaveDataFromF9(DocumentDto<F9DataDto> dataContainer)
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

            foreach (F9DataDto item in dataContainer.ZapList)
            {
                StatType statType = new StatType()
                {
                    StatusName = item.Name
                };

                long statTypeId;

                StatType existingStatType = await _statTypeService.GetEnitityByAttributes(statType);
                if (existingStatType != null)
                {
                    statTypeId = existingStatType.Id;
                }
                else
                {
                    statTypeId = (await _statTypeService.SaveStatTypeObject(statType)).Id;
                }

                f009_StatZl f009_StatZl = new f009_StatZl()
                {
                    BaseDataId = baseDataId,
                    StatTypeId = statTypeId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                        ? null
                        : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f009_StatZlId;

                f009_StatZl existingF009_StatZl = await this.GetEnitityByAttributes(f009_StatZl);
                if (existingF009_StatZl != null)
                {
                    f009_StatZlId = existingF009_StatZl.StatusId;
                }
                else
                {
                    f009_StatZlId = (await this.SaveF009_StatZlObject(f009_StatZl)).StatusId;
                }
            }

            return true;
        }

        public async Task<f009_StatZl> SaveF009_StatZlObject(f009_StatZl entityData)
        {
            return await _f009_StatZlRepository.SaveData(entityData);
        }

        public async Task<f009_StatZl> GetEnitityByAttributes(f009_StatZl entityData)
        {
            return await _f009_StatZlRepository.GetEnitityByAttributes(entityData);
        }
    }
}
