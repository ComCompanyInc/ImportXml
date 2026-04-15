using BackendApp.Dto;
using BackendApp.Dto.f032_trmos;
using BackendApp.Dto.f033_spmo;
using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F033_SpmosService
    {
        private readonly F033_SpmoRepository _f033_SpmosRepository;

        private readonly BaseDataService _baseDataService;
        private readonly CommunicationService _communicationService;
        private readonly OspTypeService _ospTypeService;
        private readonly OrgDocumentService _orgDocumentService;
        private readonly OidTypeService _oidTypeService;
        private readonly VidTypeService _vidTypeService;

        public F033_SpmosService(
            F033_SpmoRepository f033_SpmosRepository,
            BaseDataService baseDataService,
            CommunicationService communicationService,
            OspTypeService ospTypeService,
            OrgDocumentService orgDocumentService,
            OidTypeService oidTypeService,
            VidTypeService vidTypeService
        )
        {
            _f033_SpmosRepository = f033_SpmosRepository;

            _baseDataService = baseDataService;
            _communicationService = communicationService;
            _ospTypeService = ospTypeService;
            _orgDocumentService = orgDocumentService;
            _oidTypeService = oidTypeService;
            _vidTypeService = vidTypeService;
        }

        public async Task<bool> SaveDataFromF33(DocumentDto<F33DataDto> dataContainer)
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

            foreach (F33DataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                //каждую новую итерацию нового элемента, создаем обьекты с данными из XML и сохраняем его по разным сущностям
                Communication communication = new Communication
                {
                    Phone = item.Phone
                }; // данные контактов

                long communicationId;

                // если обьект уже существует в БД - сразу берем у него ID, иначе создаем его и берем у новосозданного Id
                Communication existingCommunication = await _communicationService.GetEnitityByAttributes(communication);
                if (existingCommunication != null)
                {
                    communicationId = existingCommunication.Id;
                }
                else
                {
                    communicationId = (await _communicationService.SaveCommunicationObject(communication)).Id;
                }

                OspType ospType = new OspType
                {
                    Name = item.Osp
                };

                long ospId;

                OspType existingOsp = await _ospTypeService.GetEnitityByAttributes(ospType);
                if (existingOsp != null)
                {
                    ospId = existingOsp.Id;
                }
                else
                {
                    ospId = (await _ospTypeService.SaveOspTypeObject(ospType)).Id;
                }

                OidType oidType = new OidType
                {
                    Name = item.Name
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

                VidType vidType = new VidType
                {
                    Name = item.VidType
                };

                long vidTypeSpmoId;

                VidType existingVid = await _vidTypeService.GetEnitityByAttributes(vidType);
                if (existingVid != null)
                {
                    vidTypeSpmoId = existingVid.Id;
                }
                else
                {
                    vidTypeSpmoId = (await _vidTypeService.SaveVidTypeObject(vidType)).Id;
                }

                OrgDocument orgDocument = new OrgDocument
                {
                    OidTypeSpmoId = oidTypeSpmoId,
                    VidTypeId = vidTypeSpmoId
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

                f033_spmo f033_spmo = new f033_spmo
                {
                    BaseDataId = baseDataId,
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    OspTypeId = ospId,
                    OrgDocumentId = orgDocumentId,
                    CommunicationId = communicationId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null)
                };

                string f033_SpmoId;

                f033_spmo existingF033_Spmo = await this.GetEnitityByAttributes(f033_spmo);
                if (existingF033_Spmo != null)
                {
                    f033_SpmoId = existingF033_Spmo.Id;
                }
                else
                {
                    f033_SpmoId = (await this.SaveF033_spmoObject(f033_spmo)).Id;
                }
            }

            return true;
        }

        public async Task<f033_spmo> SaveF033_spmoObject(f033_spmo f033_Spmo)
        {
            return await _f033_SpmosRepository.SaveData(f033_Spmo);
        }

        public async Task<f033_spmo> GetEnitityByAttributes(f033_spmo f033_ErmoData)
        {
            return await _f033_SpmosRepository.GetEnitityByAttributes(f033_ErmoData);
        }
    }
}
