using BackendApp.Dto;
using BackendApp.Dto.f031_ermos;
using BackendApp.Dto.f032_trmos;
using BackendApp.Helpers;
using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F032_TrmosService
    {
        private readonly F032_TrmoRepository _f032_TrmosRepository;

        private readonly BaseDataService _baseDataService;
        private readonly CommunicationService _communicationService;
        private readonly OrganizationService _organizationService;
        private readonly DocumentService _documentService;
        private readonly OrgDocumentService _moDocumentService;
        private readonly AddressService _addressService;
        private readonly VidTypeService _vidMoService;
        private readonly OspTypeService _ospService;
        private readonly SubjectService _subjectService;
        private readonly DistrictService _districtService;
        private readonly F031_ErmosService _f031_ermosService;
        private readonly OidTypeService _oidTypeService;

        public F032_TrmosService(
            F032_TrmoRepository f032_TrmosRepository,
            BaseDataService baseDataService,
            CommunicationService communicationService,
            OrganizationService organizationService,
            DocumentService documentService,
            OrgDocumentService moDocumentService,
            AddressService addressService,
            VidTypeService vidMoService,
            OspTypeService ospService,
            SubjectService subjectService,
            DistrictService districtService,
            F031_ErmosService f031_ermosService,
            OidTypeService oidTypeService
         )
        {
            _f032_TrmosRepository = f032_TrmosRepository;

            _baseDataService = baseDataService;
            _communicationService = communicationService;
            _organizationService = organizationService;
            _documentService = documentService;
            _moDocumentService = moDocumentService;
            _addressService = addressService;
            _vidMoService = vidMoService;
            _ospService = ospService;
            _subjectService = subjectService;
            _districtService = districtService;
            _f031_ermosService = f031_ermosService;
            _oidTypeService = oidTypeService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF32(DocumentDto<F32DataDto> dataContainer)
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

            foreach (F32DataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                //каждую новую итерацию нового элемента, создаем обьекты с данными из XML и сохраняем его по разным сущностям
                Communication communication = new Communication
                {
                    Phone = item.Phone,
                    Fax = item.Fax,
                    Email = item.Email,
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

                Organization organization = new Organization
                {
                    Name = item.OrgName,
                    ShortName = item.OrgShortName,
                    VedPri = item.VedPri,
                    NameE = item.NameE,
                    Mcod = item.Mcod,
                };

                long organizationId;

                Organization existingOrganization = await _organizationService.GetEnitityByAttributes(organization);
                if (existingOrganization != null)
                {
                    organizationId = existingOrganization.Id;
                }
                else
                {
                    organizationId = (await _organizationService.SaveOrganizationObject(organization)).Id;
                }

                Document document = new Document
                {
                    Inn = item.Inn,
                    Kpp = item.Kpp,
                    Ogrn = item.Ogrn
                };

                long documentId;

                Document existingDocument = await _documentService.GetEnitityByAttributes(document);
                if (existingDocument != null)
                {
                    documentId = existingDocument.Id;
                }
                else
                {
                    documentId = (await _documentService.SaveDocumentObject(document)).Id;
                }

                VidType vidMo = new VidType()
                {
                    Name = item.VidMo
                };

                long vidMoId;

                VidType existingVidMo = await _vidMoService.GetEnitityByAttributes(vidMo);
                if (existingVidMo != null)
                {
                    vidMoId = existingVidMo.Id;
                }
                else
                {
                    vidMoId = (await _vidMoService.SaveVidTypeObject(vidMo)).Id;
                }

                OidType oidTypeMo = new OidType
                {
                    Name = item.OidMo,
                };

                long oidTypeMoId;
                OidType existingOidTypeMo = await _oidTypeService.GetEnitityByAttributes(oidTypeMo);
                if (existingOidTypeMo != null)
                {
                    oidTypeMoId = existingOidTypeMo.Id;
                }
                else
                {
                    oidTypeMoId = (await _oidTypeService.SaveOidTypeObject(oidTypeMo)).Id;
                }

                OidType oidTypeSpmo = new OidType
                {
                    Name = item.OidSpmo,
                };

                long oidTypeSpmoId;
                OidType existingOidTypeSpmo = await _oidTypeService.GetEnitityByAttributes(oidTypeSpmo);
                if (existingOidTypeSpmo != null)
                {
                    oidTypeSpmoId = existingOidTypeSpmo.Id;
                }
                else
                {
                    oidTypeSpmoId = (await _oidTypeService.SaveOidTypeObject(oidTypeSpmo)).Id;
                }

                OrgDocument orgDocument = new OrgDocument
                {
                    Okfs = item.Okfs,
                    DateBeg = DateTime.Today,
                    VidTypeId = vidMoId,
                    OidTypeMoId = oidTypeMoId,
                    OidTypeSpmoId = oidTypeSpmoId,
                };

                long orgDocumentId;

                OrgDocument existingOrgDocument = await _moDocumentService.GetEnitityByAttributes(orgDocument);
                if (existingOrgDocument != null)
                {
                    orgDocumentId = existingOrgDocument.Id;
                }
                else
                {
                    orgDocumentId = (await _moDocumentService.SaveOrgDocument(orgDocument)).Id;
                }

                Subject subject = new Subject
                {
                    Name = item.Subject
                };

                long subjectId;

                Subject existingSubject = await _subjectService.GetEnitityByAttributes(subject);
                if (existingSubject != null)
                {
                    subjectId = existingSubject.Id;
                }
                else
                {
                    subjectId = (await _subjectService.SaveSubjectObject(subject)).Id;
                }

                District district = new District
                {
                    SubjectId = subjectId
                };

                long districtId;

                District existingDistrict = await _districtService.GetEnitityByAttributes(district);
                if (existingDistrict != null)
                {
                    districtId = existingDistrict.Id;
                }
                else
                {
                    districtId = (await _districtService.SaveDistrictObject(district)).Id;
                }

                Address address = new Address
                {
                    Oktmo = item.Oktmo,
                    Name = item.AddressName,
                    AddressCode = item.AddressCode,
                    Index = item.Index,
                    DistrictId = districtId
                };

                long addressId;

                Address existingAddress = await _addressService.GetEnitityByAttributes(address);
                if (existingAddress != null)
                {
                    addressId = existingAddress.Id;
                }
                else
                {
                    addressId = (await _addressService.SaveAddressObject(address)).Id;
                }

                OspType ospType = new OspType()
                {
                    Name = item.Osp
                };

                long ospTypeId;

                OspType existingOspType = await _ospService.GetEnitityByAttributes(ospType);
                if (existingOspType != null)
                {
                    ospTypeId = existingOspType.Id;
                }
                else
                {
                    ospTypeId = (await _ospService.SaveOspTypeObject(ospType)).Id;
                }

                f032_trmo f032_trmo = new f032_trmo
                {
                    Id = item.Id,
                    f031_ermoId = item.F031_ErmosId,

                    ExclusionDate = ConverterType.convertStringToData(item.ExclusionDate),
                    InclusionDate = DateTime.ParseExact(item.InclusionDate, "dd.MM.yyyy", null),
                    DateBeginOms = DateTime.ParseExact(item.DateBeginOms, "dd.MM.yyyy", null),
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = ConverterType.convertStringToData(item.DateEnd),
                    f031_ermoParentId = item.ParentIdMo,
                    ParentId = item.ParentId,

                    BaseDataId = baseDataId,
                    OrgDocumentId = orgDocumentId,
                    OrganizationId = organizationId,
                    DocumentId = documentId,
                    AddressId = addressId,
                    CommunicationId = communicationId,
                    OspTypeId = ospTypeId,
                };

                f031_ermo existingF031 = await _f031_ermosService.GetEnitityByAttributes(new f031_ermo { Id = item.F031_ErmosId });
                f031_ermo existingF031Parent = await _f031_ermosService.GetEnitityByAttributes(new f031_ermo { Id = item.ParentIdMo });
                if (existingF031 != null)
                {
                    if (existingF031Parent != null)
                    {
                        if (await this.GetEnitityByAttributes(f032_trmo) == null)
                        {
                            await SaveF032_trmoObject(f032_trmo);
                        }
                    } else {
                        errors.Add(
                            new ErrorResponseDto
                            {
                                ErrorMessage = $"ОШИБКА: В ЗАПИСИ F032_Trmo с ID = {item.Id} - в таблице F031_Ermo, первичный ключ ID (IDMO), как f031_ermoParentId - {item.ParentIdMo} не найден. Сначала импортируйте документ F031_Ermo перед загрузкой документа F032_Trmo!",
                                ConflictObject = f032_trmo
                            }
                        );
                    }
                } else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = $"ОШИБКА: В ЗАПИСИ F032_Trmo с ID = {item.Id} - в таблице F031_Ermo, первичный ключ ID (IDMO) - {item.F031_ErmosId} не найден. Сначала импортируйте документ F031_Ermo перед загрузкой документа F032_Trmo!",
                            ConflictObject = f032_trmo
                        }
                    );
                }
            }

            return errors;
        }

        public async Task<f032_trmo> SaveF032_trmoObject(f032_trmo f032_trmo)
        {
            return await _f032_TrmosRepository.SaveData(f032_trmo);
        }

        public async Task<f032_trmo> GetEnitityByAttributes(f032_trmo f032_TrmoData)
        {
            return await _f032_TrmosRepository.GetEnitityByAttributes(f032_TrmoData);
        }
    }
}
