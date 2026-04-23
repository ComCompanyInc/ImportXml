using BackendApp.Dto;
using BackendApp.Dto.f006_videxp;
using BackendApp.Dto.f007_vedom;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F007_VedomService
    {
        private readonly F007_VedomRepository _f007_VedomRepository;

        private readonly BaseDataService _baseDataService;
        private readonly VedomTypeService _vedomTypeService;

        public F007_VedomService(
            F007_VedomRepository f007_VedomRepository,
            BaseDataService baseDataService,
            VedomTypeService vedomTypeService
        )
        {
            _f007_VedomRepository = f007_VedomRepository;

            _baseDataService = baseDataService;
            _vedomTypeService = vedomTypeService;
        }

        public async Task<bool> SaveDataFromF7(DocumentDto<F7DataDto> dataContainer)
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

            foreach (F7DataDto item in dataContainer.ZapList)
            {
                VedomType vedomType = new VedomType()
                {
                    Name = item.VedName
                };

                long vedomTypeId;

                VedomType existingVedomType = await _vedomTypeService.GetEnitityByAttributes(vedomType);
                if (existingVedomType != null)
                {
                    vedomTypeId = existingVedomType.Id;
                }
                else
                {
                    vedomTypeId = (await _vedomTypeService.SaveVedomTypeObject(vedomType)).Id;
                }

                f007_Vedom f007_Vedom = new f007_Vedom()
                {
                    BaseDataId = baseDataId,
                    VedomTypeId = vedomTypeId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                        ? null
                        : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f007_VedomId;

                f007_Vedom existingF007_Vedom = await this.GetEnitityByAttributes(f007_Vedom);
                if (existingF007_Vedom != null)
                {
                    f007_VedomId = existingF007_Vedom.VedId;
                }
                else
                {
                    f007_VedomId = (await this.SaveF007_VedomObject(f007_Vedom)).VedId;
                }
            }

            return true;
        }

        public async Task<f007_Vedom> SaveF007_VedomObject(f007_Vedom entityData)
        {
            return await _f007_VedomRepository.SaveData(entityData);
        }

        public async Task<f007_Vedom> GetEnitityByAttributes(f007_Vedom entityData)
        {
            return await _f007_VedomRepository.GetEnitityByAttributes(entityData);
        }
    }
}
