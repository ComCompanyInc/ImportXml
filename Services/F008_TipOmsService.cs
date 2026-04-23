using BackendApp.Data;
using BackendApp.Dto;
using BackendApp.Dto.f007_vedom;
using BackendApp.Dto.f008_TipOms;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F008_TipOmsService
    {
        private readonly F008_TipOmsRepository _f008_TipOmsRepository;

        private readonly BaseDataService _baseDataService;
        private readonly OmsTypeService _omsTypeService;

        public F008_TipOmsService(
            F008_TipOmsRepository f008_TipOmsRepository,
            BaseDataService baseDataService,
            OmsTypeService omsTypeService
        )
        {
            _f008_TipOmsRepository = f008_TipOmsRepository;

            _baseDataService = baseDataService;
            _omsTypeService = omsTypeService;
        }

        public async Task<bool> SaveDataFromF8(DocumentDto<F8DataDto> dataContainer)
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

            foreach (F8DataDto item in dataContainer.ZapList)
            {
                OmsType omsType = new OmsType()
                {
                    Name = item.OmsTypeName
                };

                long omsTypeId;

                OmsType existingOmsType = await _omsTypeService.GetEnitityByAttributes(omsType);
                if (existingOmsType != null)
                {
                    omsTypeId = existingOmsType.Id;
                }
                else
                {
                    omsTypeId = (await _omsTypeService.SaveF008_TipOmsObject(omsType)).Id;
                }

                f008_TipOms f008_TipOms = new f008_TipOms()
                {
                    BaseDataId = baseDataId,
                    OmsTypeId = omsTypeId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                        ? null
                        : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f008_TipOmsId;

                f008_TipOms existingF008_TipOms = await this.GetEnitityByAttributes(f008_TipOms);
                if (existingF008_TipOms != null)
                {
                    f008_TipOmsId = existingF008_TipOms.DocId;
                }
                else
                {
                    f008_TipOmsId = (await this.SaveF008_TipOmsObject(f008_TipOms)).DocId;
                }
            }

            return true;
        }

        public async Task<f008_TipOms> SaveF008_TipOmsObject(f008_TipOms entityData)
        {
            return await _f008_TipOmsRepository.SaveData(entityData);
        }

        public async Task<f008_TipOms> GetEnitityByAttributes(f008_TipOms entityData)
        {
            return await _f008_TipOmsRepository.GetEnitityByAttributes(entityData);
        }
    }
}
