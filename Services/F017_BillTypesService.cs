using BackendApp.Dto;
using BackendApp.Dto.f017_billtypes;
using BackendApp.Dto.f031_ermos;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F017_BillTypesService
    {
        private readonly F017_BillTypesRepository _f017_BillTypesRepository;

        private readonly BaseDataService _baseDataService;
        private readonly SubjectService _subjectService;
        private readonly F012_TipSchService _f012_tipSchService;
        private readonly OrgTypeService _orgTypeService;

        public F017_BillTypesService(
            F017_BillTypesRepository f017_BillTypesRepository,
            BaseDataService baseDataService,
            SubjectService subjectService,
            F012_TipSchService f012_tipSchService,
            OrgTypeService orgTypeService
        )
        {
            _f017_BillTypesRepository = f017_BillTypesRepository;

            _baseDataService = baseDataService;
            _subjectService = subjectService;
            _f012_tipSchService = f012_tipSchService;
            _orgTypeService = orgTypeService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF17(DocumentDto<F17DataDto> dataContainer)
        {
            List<ErrorResponseDto> errors = new List<ErrorResponseDto>();

            BaseData baseData = new BaseData
            {
                Type = dataContainer.BaseData.Type,
                Version = dataContainer.BaseData.Version,
                Date = DateTime.ParseExact(dataContainer.BaseData.Date, "dd.MM.yyyy", null)
            }; // создаем обьект с заголовком и передаем в него данные из документа

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

            foreach (F17DataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                long subjectId;

                Subject existingSubject = await _subjectService.FindSubjectByOkato(item.Okato);
                if (existingSubject == null)
                {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "ОШИБКА: Субьект из таблицы Subject по ОКАТО: " + item.Okato + " не был найден. Попробуйте сначала экспортировать F010_Subecti и повторите попытку еще раз.",
                            ConflictObject = existingSubject
                        }
                    );

                    continue;
                }
                else {
                    subjectId = existingSubject.Id;
                }

                OrgType orgType = new OrgType
                {
                    OrgTypeName = item.OrgType
                };

                long orgTypeId;

                OrgType existingOrgType = await _orgTypeService.GetEnitityByAttributes(orgType);
                if (existingOrgType != null)
                {
                    orgTypeId = existingOrgType.Id;
                }
                else
                {
                    orgTypeId = (await _orgTypeService.SaveOrgTypeObject(orgType)).Id;
                }

                f012_TipSch f012_TipSch = new f012_TipSch
                {
                    SchId = item.F012_TipSchId,
                    Name = item.Name,
                    ShortName = item.ShortName
                };

                string f012_TipSchId;

                f012_TipSch existingF012_TipSch = await _f012_tipSchService.GetEnitityByAttributes(f012_TipSch);
                if (existingF012_TipSch != null)
                {
                    f012_TipSchId = existingF012_TipSch.SchId;
                }
                else
                {
                    f012_TipSchId = (await _f012_tipSchService.SaveF012_TipSchObject(f012_TipSch)).SchId;
                }

                f017_BillTypes f017_BillTypes = new f017_BillTypes
                {
                    BaseDataId = baseDataId,
                    BudgetSource = item.BudgetSource,
                    f012_TipSchId = item.F012_TipSchId,
                    Subject = existingSubject,
                    SubjectId = subjectId,
                    OrgTypeId = orgTypeId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f017_BillTypesId;

                f017_BillTypes existingF017_BillTypes = await this.GetEnitityByAttributes(f017_BillTypes);
                if (existingF017_BillTypes != null)
                {
                    f017_BillTypesId = existingF017_BillTypes.Id;
                }
                else
                {
                    f017_BillTypesId = (await this.SaveF017_BillTypesObject(f017_BillTypes)).Id;
                }
            }

            return errors;
        }

        public async Task<f017_BillTypes> SaveF017_BillTypesObject(f017_BillTypes entityData)
        {
            return await _f017_BillTypesRepository.SaveData(entityData);
        }

        public async Task<f017_BillTypes> GetEnitityByAttributes(f017_BillTypes entityData)
        {
            return await _f017_BillTypesRepository.GetEnitityByAttributes(entityData);
        }
    }
}
