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
        private readonly F037_LicMoRepository _f037_LicMoRepository;

        private readonly BaseDataService _baseDataService;
        private readonly OidTypeService _oidTypeService;
        private readonly OrgDocumentService _orgDocumentService;
        private readonly OrganizationService _organizationService;

        public F037_LicmoService(
            F037_LicMoRepository f037_LicMoRepository,
            BaseDataService baseDataService,
            OidTypeService oidTypeService,
            OrgDocumentService orgDocumentService,
            OrganizationService organizationService
        )
        {
            _f037_LicMoRepository = f037_LicMoRepository;
            _baseDataService = baseDataService;
            _oidTypeService = oidTypeService;
            _orgDocumentService = orgDocumentService;
            _organizationService = organizationService;
        }

        public async Task<bool> SaveDataFromF37(DocumentDto<F37DataDto> dataContainer)
        {
            /*List<ErrorResponseDto> errors = new List<ErrorResponseDto>();

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

                OidType oidType = new OidType
                {
                    Name = item.OidMo
                };

                long oidTypeSpmoId;

                OidType existingOid = await _oidTypeService.GetEnitityByAttributes(oidType);
                if (existingOid != null)
                {
                    oidTypeSpmoId = existingOid.Id;
                }
                else
                {
                    oidTypeSpmoId = (await _oidTypeService.SaveOidTypeObject(oidType)).Id;
                }

                OrgDocument orgDocument = new OrgDocument
                {
                    OidTypeSpmoId = oidTypeSpmoId,
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

                Organization organization = _organizationService.GetEnitityByAttributes(new Organization { Mcod = item.MCode });
                if (organization != null)
            */

                return true;
            //}
        }
    }
}
