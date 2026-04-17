using BackendApp.Data;
using BackendApp.Dto;
using BackendApp.Dto.f037_licmo;
using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F037_LicmoService
    {
        private readonly F037_LicmoRepository _f037_LicMoRepository;

        private readonly BaseDataService _baseDataService;
        private readonly OidTypeService _oidTypeService;
        private readonly OrgDocumentService _orgDocumentService;
        private readonly OrganizationService _organizationService;
        private readonly LicenseService _licenseService;
        private readonly F032_TrmosService _f032_TrmosService;

        public F037_LicmoService(
            F037_LicmoRepository f037_LicMoRepository,
            BaseDataService baseDataService,
            OidTypeService oidTypeService,
            OrgDocumentService orgDocumentService,
            OrganizationService organizationService,
            LicenseService licenseService,
            F032_TrmosService f032_TrmosService
        )
        {
            _f037_LicMoRepository = f037_LicMoRepository;
            _baseDataService = baseDataService;
            _oidTypeService = oidTypeService;
            _orgDocumentService = orgDocumentService;
            _organizationService = organizationService;
            _licenseService = licenseService;
            _f032_TrmosService = f032_TrmosService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF37(DocumentDto<F37DataDto> dataContainer)
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

            foreach (F37DataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                //license f031 f032

                Models.License license = new Models.License()
                {
                    LicenseNum = item.LicenseNum,
                };

                long licenseId;

                Models.License existingLicense = await _licenseService.GetEnitityByAttributes(license);
                if (existingLicense != null)
                {
                    licenseId = existingLicense.Id;
                }
                else
                {
                    licenseId = (await _licenseService.SaveLicenseObject(license)).Id;
                }

                OidType oidType = new OidType
                {
                    Name = item.OidMo
                };

                long oidTypeMoId;

                OidType existingOid = await _oidTypeService.GetEnitityByAttributes(oidType);
                if (existingOid != null)
                {
                    oidTypeMoId = existingOid.Id;
                }
                else
                {
                    oidTypeMoId = (await _oidTypeService.SaveOidTypeObject(oidType)).Id;
                }

                OrgDocument orgDocument = new OrgDocument
                {
                    OidTypeMoId = oidTypeMoId,
                    //VidTypeId = vidTypeSpmoId
                };

                long orgDocumentId;

                OrgDocument existingOrgDocument = await _orgDocumentService.GetEnitityByAttributes(orgDocument);
                if (existingOrgDocument != null)
                {
                    orgDocumentId = existingOrgDocument.Id;
                }
                else
                {
                    orgDocumentId = (await _orgDocumentService.SaveOrgDocument(orgDocument)).Id;
                }

                //Organization organizationEntity = new Organization
                //{
                //    Mcod = item.MCode
                //};

                long? organizationId = null;
                Organization organization = await _organizationService.FindOrganizationByMcod(item.MCode);
                if (organization != null && item.MCode != null)
                {
                    organizationId = organization.Id;
                }
                else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = $"ПРЕДУПРЕЖДЕНИЕ: В ЗАПИСИ F037_Licmos с ID = {item.Id} - в таблице F037_Licmos, Запись Mcod в таблице Organizations - {item.MCode} не найдена.",
                            ConflictObject = { }
                        }
                    );
                }

                f037_licmo f037_Licmo = new f037_licmo
                {
                    F031_ErmoId = item.F031_ErmoId,
                    F032_TrmoId = item.F032_TrmoId,
                    OrganizationId = organizationId,
                    OrgDocumentId = orgDocumentId,
                    LicenseId = licenseId,
                };

                f032_trmo existingF032 = await _f032_TrmosService.GetEnitityByAttributes(new f032_trmo { Id = item.F032_TrmoId });
                if (existingF032 != null)
                {
                    await SaveF037_licmoObject(f037_Licmo);
                }
                else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = $"ОШИБКА: В ЗАПИСИ F037_Licmos с ID = {item.Id} - в таблице F037_Licmos, Запись Mcod в таблице Organizations - {item.MCode} не найдена.",
                            ConflictObject = organization
                        }
                    );
                }
            }

            return errors;
        }

        public async Task<f037_licmo> SaveF037_licmoObject(f037_licmo f037_Licmo)
        {
            return await _f037_LicMoRepository.SaveData(f037_Licmo);
        }

        public async Task<f037_licmo> GetEnitityByAttributes(f037_licmo f037_Licmo)
        {
            return await _f037_LicMoRepository.GetEnitityByAttributes(f037_Licmo);
        }
    }
}
