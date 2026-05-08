using BackendApp.Dto;
using BackendApp.Dto.f010_subecti;
using BackendApp.Dto.f012_tipsch;
using BackendApp.Dto.f019_PersAccOrg;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace BackendApp.Services
{
    public class F019_PersAccOrgService
    {
        private readonly F019_PersAccOrgRepository _f019_PersAccOrgRepository;
        
        private readonly BaseDataService _baseDataService;
        private readonly F001_TfomsService _f001_TfomsService;
        private readonly F002_SmoEmpService _f002_SmoEmpService;
        private readonly OrganizationService _organizationService;
        private readonly OrgNameService _orgNameService;
        private readonly SubjectService _subjectService;
        private readonly F010_SubectiService _f010_SubectiService;
        private readonly OrgTypeService _orgTypeService;

        public F019_PersAccOrgService(
            F019_PersAccOrgRepository f019_PersAccOrgRepository,
            
            BaseDataService baseDataService,
            F001_TfomsService f001_TfomsService,
            F002_SmoEmpService f002_SmoEmpService,
            OrganizationService organizationService,
            OrgNameService orgNameService,
            SubjectService subjectService,
            F010_SubectiService f010_SubectiService,
            OrgTypeService orgTypeService
        )
        {
            _f019_PersAccOrgRepository = f019_PersAccOrgRepository;

            _baseDataService = baseDataService;
            _f001_TfomsService = f001_TfomsService;
            _f002_SmoEmpService = f002_SmoEmpService;
            _organizationService = organizationService;
            _orgNameService = orgNameService;
            _subjectService = subjectService;
            _f010_SubectiService = f010_SubectiService;
            _orgTypeService = orgTypeService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF19(DocumentDto<F19DataDto> dataContainer)
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

            foreach (F19DataDto item in dataContainer.ZapList)
            {
                long subjectId;

                Subject existingSubject = await _subjectService.FindSubjectByOkato(item.TfOkato);
                if (existingSubject != null)
                {
                    subjectId = existingSubject.Id;
                } else
                {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Ошибка: в таблице Subject с с записью Okato = " + item.TfOkato + " не найдено совпадений. "
                            + "Импортируйте данные справочника F010_Subecti и повторите попытку снова",
                            ConflictObject = existingSubject
                        }
                    );

                    continue;
                }

                f010_Subecti f010_Subecti = new f010_Subecti
                {
                    SubjectId = subjectId,
                    Subject = existingSubject,
                    CodeTf = item.TfCode,
                };

                long f010_SubectiId;

                f010_Subecti existingF010_Subecti = await _f010_SubectiService.GetEnitityByAttributes(f010_Subecti);
                //Console.WriteLine("\nexistingF010 -> " + JsonSerializer.Serialize(existingF010_Subecti) + "\n");
                if (existingF010_Subecti != null)
                {
                    f010_SubectiId = existingF010_Subecti.Id;
                }
                else
                {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Ошибка: в таблице F010_Subecti с с записью SubjectId = " + subjectId + " и CodeTf = " + item.TfCode + " не найдено совпадений. "
                            + "Импортируйте данные справочника F010_Subecti и повторите попытку снова",
                            ConflictObject = existingF010_Subecti
                        }
                    );

                    continue;
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
                else {
                    orgTypeId = (await _orgTypeService.SaveOrgTypeObject(orgType)).Id;
                }

                OrgName orgName = new OrgName
                {
                    Name = item.OrgName,
                    ShortName = item.OrgNameShort
                };

                long orgNameId;

                OrgName existingOrgName = await _orgNameService.GetEnitityByAttributes(orgName);
                if (existingOrgName != null)
                {
                    orgNameId = existingOrgName.Id;
                }
                else
                {
                    orgNameId = (await _orgNameService.SaveOrgNameObject(orgName)).Id;
                }

                Organization organization = new Organization
                {
                    OrgNameId = orgNameId,
                    OrgCode = item.OrgCode
                };

                long OrganizationId;

                Organization existingOrganization = await _organizationService.GetEnitityByAttributes(organization);
                if (existingOrganization != null)
                {
                    OrganizationId = existingOrganization.Id;
                }
                else
                {
                    OrganizationId = (await _organizationService.SaveOrganizationObject(organization)).Id;

                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Предупреждение: Была созданна новая организация (т.к. по имени не была найдена)",
                            ConflictObject = existingSubject
                        }
                    );
                }

                f001_tfoms f001_Tfoms = new f001_tfoms
                {
                    F010_Subecti = existingF010_Subecti,
                    f010_SubectiId = f010_SubectiId
                };

                long f001_TfomsId;

                f001_tfoms existingF001_Tfoms = await _f001_TfomsService.GetEnitityByAttributes(f001_Tfoms);
                if (existingF001_Tfoms != null)
                {
                    f001_TfomsId = existingF001_Tfoms.Id;
                }
                else
                {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Ошибка: в таблице F001_Tfoms по f010_SubectiId = " + f010_SubectiId + " не был найден. "
                                + "Требуется импортировать справочник F001_Tfoms и f010_Subecti и повторить попытку",
                            ConflictObject = existingF001_Tfoms
                        }
                    );

                    continue;
                }

                f002_smoEmp f002_SmoEmp = new f002_smoEmp
                {
                    SmoCod = item.SmoCode
                };

                string? f002_SmoEmpId = null;

                f002_smoEmp existingF002_smoEmp = await _f002_SmoEmpService.GetEnitityByAttributes(f002_SmoEmp);
                if (existingF002_smoEmp != null)
                {
                    f002_SmoEmpId = existingF002_smoEmp.SmoCod;
                }
                //else
                //{
                //    errors.Add(
                //            new ErrorResponseDto
                //            {
                //                ErrorMessage = "Ошибка: в таблице F002_SmoEmp по аттрибуту идентификатора SmoCod = " + item.SmoCode + " не была найдена сущность. "
                //                    + "Требуется импортировать справочник F002_SmoEmp и повторить попытку",
                //                ConflictObject = existingF002_smoEmp
                //            }
                //        );

                //    continue;
                //}

                //TODO: реализовать сохранение главной сущности F019 
                f019_PersAccOrg f019_PersAccOrg = new f019_PersAccOrg
                {
                    SubjectId = subjectId,
                    F001_TfomsId = f001_TfomsId,
                    F002_SmoEmpId = f002_SmoEmpId,
                    OrganizationId = OrganizationId,

                    Organization = existingOrganization,

                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                f019_PersAccOrg existingF019PersAccOrg = await this.GetEnitityByAttributes(f019_PersAccOrg);
                if (existingF019PersAccOrg == null)
                {
                    await this.SaveF019_PersAccOrg(f019_PersAccOrg);
                }
            }

            return errors;
        }

        public async Task<f019_PersAccOrg> SaveF019_PersAccOrg(f019_PersAccOrg existingData)
        {
            return await _f019_PersAccOrgRepository.SaveData(existingData);
        }

        public async Task<f019_PersAccOrg> GetEnitityByAttributes(f019_PersAccOrg existingData)
        {
            return await _f019_PersAccOrgRepository.GetEnitityByAttributes(existingData);
        }
    }
}
