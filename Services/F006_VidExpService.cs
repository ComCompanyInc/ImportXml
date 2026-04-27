using BackendApp.Dto;
using BackendApp.Dto.f002_smo_emp;
using BackendApp.Dto.f006_videxp;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F006_VidExpService
    {
        private readonly F006_VidExpRepository _f006_VidExpRepository;

        private readonly BaseDataService _baseDataService;
        private readonly ExpTypeService _expTypeService;

        public F006_VidExpService(
            F006_VidExpRepository f006_VidExpRepository,
            BaseDataService baseDataService,
            ExpTypeService expTypeService
        )
        {
            _f006_VidExpRepository = f006_VidExpRepository;

            _baseDataService = baseDataService;
            _expTypeService = expTypeService;
        }

        public async Task<bool> SaveDataFromF6(DocumentDto<F6DataDto> dataContainer)
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

            foreach (F6DataDto item in dataContainer.ZapList)
            {
                ExpType expType = new ExpType()
                {
                    Name = item.Name
                };

                long expTypeId;

                ExpType existingExpType = await _expTypeService.GetEnitityByAttributes(expType);
                if (existingExpType != null)
                {
                    expTypeId = existingExpType.Id;
                }
                else
                {
                    expTypeId = (await _expTypeService.SaveExpTypeObject(expType)).Id;
                }

                f006_VidExp f006_VidExp = new f006_VidExp()
                {
                    BaseDataId = baseDataId,
                    ExpTypeId = expTypeId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                        ? null
                        : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f006_VidExpId;

                f006_VidExp existingf006_VidExp = await this.GetEnitityByAttributes(f006_VidExp);
                if (existingf006_VidExp != null)
                {
                    f006_VidExpId = existingf006_VidExp.VidId;
                }
                else
                {
                    f006_VidExpId = (await this.SaveF006_VidObject(f006_VidExp)).VidId;
                }
            }

            return true;
        }

        public async Task<f006_VidExp> SaveF006_VidObject(f006_VidExp entityData)
        {
            return await _f006_VidExpRepository.SaveData(entityData);
        }

        public async Task<f006_VidExp> GetEnitityByAttributes(f006_VidExp entityData)
        {
            return await _f006_VidExpRepository.GetEnitityByAttributes(entityData);
        }
    }
}
