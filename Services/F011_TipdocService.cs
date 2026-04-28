using BackendApp.Data;
using BackendApp.Dto;
using BackendApp.Dto.f010_subecti;
using BackendApp.Dto.f011_tipdoc;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F011_TipdocService
    {
        private readonly F011_TopicRepository _f011_TopicRepository;

        private readonly BaseDataService _baseDataService;
        private readonly OmsTypeService _omsTypeService;
        private readonly F008_TipOmsService _f008_TipOmsService;

        public F011_TipdocService(
            F011_TopicRepository f011_TopicRepository,
            BaseDataService baseDataService,
            OmsTypeService omsTypeService,
            F008_TipOmsService f008_TipOmsService
        )
        {
            _f011_TopicRepository = f011_TopicRepository;

            _baseDataService = baseDataService;
            _omsTypeService = omsTypeService;
            _f008_TipOmsService = f008_TipOmsService;
        }

        public async Task<bool> SaveDataFromF11(DocumentDto<F11DataDto> dataContainer)
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

            foreach (F11DataDto item in dataContainer.ZapList)
            {
                OmsType omsType = new OmsType
                {
                    Name = item.Name
                };

                long omsTypeId;

                OmsType existingOmsType = await _omsTypeService.GetEnitityByAttributes(omsType);
                if (existingOmsType != null)
                {
                    omsTypeId = existingOmsType.Id;
                }
                else
                {
                    omsTypeId = (await _omsTypeService.SaveOmsTypeObject(omsType)).Id;
                }

                f008_TipOms f008_TipOms = new f008_TipOms
                {
                    DocId = item.IdDoc,
                    OmsTypeId = omsTypeId,
                    BaseDataId = baseDataId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null)
                };

                long f008_TipOmsId;

                f008_TipOms existingF008_TipOms = await _f008_TipOmsService.GetEnitityByAttributes(f008_TipOms);
                if (existingF008_TipOms != null)
                {
                    f008_TipOmsId = existingF008_TipOms.DocId;
                }
                else
                {
                    f008_TipOmsId = (await _f008_TipOmsService.SaveF008_TipOmsObject(f008_TipOms)).DocId;
                }

                f011_Tipdoc f011_Tipdoc = new f011_Tipdoc
                {
                    F008_TipOms = f008_TipOms,
                    F008_TipOmsId = f008_TipOmsId,
                    //BaseDataId = baseDataId,

                    DocNum = item.DocNum,
                    DocSer = item.DocSer
                };

                long f011_TipdocId;

                f011_Tipdoc existingF011_Tipdoc = await this.GetEnitityByAttributes(f011_Tipdoc);
                if (existingF011_Tipdoc != null)
                {
                    f011_TipdocId = existingF011_Tipdoc.Id;
                }
                else
                {
                    f011_TipdocId = (await this.SaveF011_TipdocObject(f011_Tipdoc)).Id;
                }
            }

            return true;
        }

        public async Task<f011_Tipdoc> SaveF011_TipdocObject(f011_Tipdoc entityData)
        {
            return await _f011_TopicRepository.SaveData(entityData);
        }

        public async Task<f011_Tipdoc> GetEnitityByAttributes(f011_Tipdoc entityData)
        {
            return await _f011_TopicRepository.GetEnitityByAttributes(entityData);
        }
    }
}
