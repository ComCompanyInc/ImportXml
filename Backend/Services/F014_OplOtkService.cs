using BackendApp.Dto;
using BackendApp.Dto.f012_tipsch;
using BackendApp.Dto.f014_oplotk;
using BackendApp.Helpers;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F014_OplOtkService
    {
        private readonly F014_OplOtkRepository _f014_OplOtkRepository;

        private readonly BaseDataService _baseDataService;
        private readonly F006_VidExpService _f006_VidExpService;
        private readonly RefusalGroundService _refusalGroundService;

        public F014_OplOtkService(
            F014_OplOtkRepository f014_OplOtkRepository,
            BaseDataService baseDataService,
            F006_VidExpService f006_VidExpService,
            RefusalGroundService refusalGroundService
        )
        {
            _f014_OplOtkRepository = f014_OplOtkRepository;

            _baseDataService = baseDataService;
            _f006_VidExpService = f006_VidExpService;
            _refusalGroundService = refusalGroundService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF14(DocumentDto<F14DataDto> dataContainer)
        {
            List<ErrorResponseDto> errors = new List<ErrorResponseDto>();

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

            foreach (F14DataDto item in dataContainer.ZapList)
            {
                RefusalGround refusalGround = new RefusalGround
                {
                    Name = item.RefusalGroundName
                };

                long refusalGroundId;

                RefusalGround existingRefusalGround = await _refusalGroundService.GetEnitityByAttributes(refusalGround);
                if (existingRefusalGround != null)
                {
                    refusalGroundId = existingRefusalGround.Id;
                }
                else
                {
                    refusalGroundId = (await _refusalGroundService.SaveRefusalGroundObject(refusalGround)).Id;
                }

                long? f006_VidExpId = null;

                if (ConverterType.FromStringToLong(item.Idvid) != null)
                {
                    f006_VidExp existingF006_VidExp = await _f006_VidExpService.GetEnitityByAttributes(new f006_VidExp { VidId = ConverterType.FromStringToLong(item.Idvid).Value});
                    if (existingF006_VidExp != null)
                    {
                        f006_VidExpId = existingF006_VidExp.VidId;
                    }
                    else
                    {
                        errors.Add(
                            new ErrorResponseDto
                            {
                                ErrorMessage = "Ошибка создания записи: в таблице F006_VidExp нет записи по идентификатору VidId = " + item.Idvid
                                + ". Для начала импортируйте данные в таблицу F006!",
                                ConflictObject = existingF006_VidExp
                            }
                        );

                        continue;
                    }
                }

                f014_OplOtk f014_OplOtk = new f014_OplOtk
                {
                    BaseDataId = baseDataId,
                    RefusalGroundId = refusalGroundId,
                    f006_VidExpVidId = f006_VidExpId,

                    ErrorCode = item.ErrorCode,
                    CoefNonPay = ConverterType.FromStringToDecimal(item.CoefNonPay),
                    CoefForfeit = ConverterType.FromStringToDecimal(item.CoefForfeit),
                    CodePG = item.CodePG,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null)
                };

                long f014_OplOtkId;

                f014_OplOtk existingF014_OplOtkId = await this.GetEnitityByAttributes(f014_OplOtk);
                if (existingF014_OplOtkId != null)
                {
                    f014_OplOtkId = existingF014_OplOtkId.Id;
                }
                else
                {
                    f014_OplOtkId = (await this.SaveF014_OplOtkObject(f014_OplOtk)).Id;
                }
            }

            return errors;
        }

        public async Task<f014_OplOtk> SaveF014_OplOtkObject(f014_OplOtk entityData)
        {
            return await _f014_OplOtkRepository.SaveData(entityData);
        }

        public async Task<f014_OplOtk> GetEnitityByAttributes(f014_OplOtk entityData)
        {
            return await _f014_OplOtkRepository.GetEnitityByAttributes(entityData);
        }
    }
}
