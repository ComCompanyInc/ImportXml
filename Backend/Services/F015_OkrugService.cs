using BackendApp.Dto;
using BackendApp.Dto.f011_tipdoc;
using BackendApp.Dto.f015_okrug;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F015_OkrugService
    {
        public readonly F015_OkrugRepository _f015_OkrugRepository;

        public readonly BaseDataService _baseDataService;
        public readonly DistrictService _districtService;
        //public readonly  _districtService;

        public F015_OkrugService(
            F015_OkrugRepository f015_OkrugRepository,
            BaseDataService baseDataService,
            DistrictService districtService
        )
        {
            _f015_OkrugRepository = f015_OkrugRepository;

            _baseDataService = baseDataService;
            _districtService = districtService;
        }

        public async Task<bool> SaveDataFromF15(DocumentDto<F15DataDto> dataContainer)
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

            foreach (F15DataDto item in dataContainer.ZapList)
            {
                District district = new District
                {
                    Name = item.DistrictName
                };

                long distirctId;

                District existingDistrictData = await _districtService.GetEnitityByAttributes(district);
                if (existingDistrictData != null)
                {
                    distirctId = existingDistrictData.Id;
                }
                else
                {
                    distirctId = (await _districtService.SaveDistrictObject(district)).Id;
                }

                f015_Okrug f015_Okrug = new f015_Okrug
                {
                    Code = item.Code,
                    DistrictId = distirctId,
                    BaseDataId = baseDataId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null)
                };

                string f015_OkrugId;

                f015_Okrug existingF015_Okrug = await this.GetEnitityByAttributes(f015_Okrug);
                if (existingF015_Okrug != null)
                {
                    f015_OkrugId = existingF015_Okrug.Code;
                }
                else
                {
                    Console.WriteLine("[PROBLEM_OBJECT] -> " + System.Text.Json.JsonSerializer.Serialize(f015_Okrug));

                    f015_OkrugId = (await this.SaveF015_OkrugObject(f015_Okrug)).Code;
                }
            }

            return true;
        }

        public async Task<f015_Okrug> SaveF015_OkrugObject(f015_Okrug entityData)
        {
            return await _f015_OkrugRepository.SaveData(entityData);
        }

        public async Task<f015_Okrug> GetEnitityByAttributes(f015_Okrug entityData)
        {
            return await _f015_OkrugRepository.GetEnitityByAttributes(entityData);
        }
    }
}
