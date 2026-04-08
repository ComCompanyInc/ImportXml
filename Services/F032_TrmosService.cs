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
        private readonly CommunicationService _comminicationService;
        private readonly OrganizationService _organizationService;
        private readonly DocumentService _documentService;
        private readonly MoDocumentService _moDocumentService;
        private readonly AddressService _addressService;
        private readonly VidMoService _vidMoService;
        private readonly OspTypeService _ospService;
        private readonly SubjectService _subjectService;
        private readonly DistrictService _districtService;

        public F032_TrmosService(
            F032_TrmoRepository f032_TrmosRepository,
            BaseDataService baseDataService,
            CommunicationService comminicationService,
            OrganizationService organizationService,
            DocumentService documentService,
            MoDocumentService moDocumentService,
            AddressService addressService,
            VidMoService vidMoService,
            OspTypeService ospService,
            SubjectService subjectService,
            DistrictService districtService
         )
        {
            _f032_TrmosRepository = f032_TrmosRepository;

            _baseDataService = baseDataService;
            _comminicationService = comminicationService;
            _organizationService = organizationService;
            _documentService = documentService;
            _moDocumentService = moDocumentService;
            _addressService = addressService;
            _vidMoService = vidMoService;
            _ospService = ospService;
            _subjectService = subjectService;
            _districtService = districtService;
        }

        public async Task<bool> SaveDataFromF32(DocumentDto<F32DataDto> dataContainer)
        {
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
                  Communication existingCommunication = await _comminicationService.GetEnitityByAttributes(communication);
                  if (existingCommunication != null)
                  {
                      communicationId = existingCommunication.Id;
                  }
                  else
                  {
                      communicationId = (await _comminicationService.SaveCommunicationObject(communication)).Id;
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

                  VidMo vidMo = new VidMo()
                  {
                      Name = item.VidMo
                  };

                  long vidMoId;

                  VidMo existingVidMo = await _vidMoService.GetEnitityByAttributes(vidMo);
                  if (existingVidMo != null)
                  {
                      vidMoId = existingVidMo.Id;
                  }
                  else
                  {
                      vidMoId = (await _vidMoService.SaveVidMoObject(vidMo)).Id;
                  }

                  MoDocument moDocument = new MoDocument
                  {
                      Okfs = item.Okfs,
                      OidMo = item.OidMo,
                      DateBeg = DateTime.Today,
                      VidMoId = vidMoId,
                      OidSpmo = item.OidSpmo
                  };

                  long moDocumentId;

                  MoDocument existingMoDocument = await _moDocumentService.GetEnitityByAttributes(moDocument);
                  if (existingMoDocument != null)
                  {
                      moDocumentId = existingMoDocument.Id;
                  }
                  else
                  {
                      moDocumentId = (await _moDocumentService.SaveMoDocument(moDocument)).Id;
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
                      InclusionDate = DateTime.ParseExact(item.InclusionDate,"dd.MM.yyyy", null),
                      DateBeginOms = DateTime.ParseExact(item.DateBeginOms, "dd.MM.yyyy", null),
                      DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                      DateEnd = ConverterType.convertStringToData(item.DateEnd),
                      f031_ermoParentId = item.ParentIdMo,
                      ParentId = item.ParentId,

                      BaseDataId = baseDataId,
                      MoDocumentId = moDocumentId,
                      OrganizationId = organizationId,
                      DocumentId = documentId,
                      AddressId = addressId,
                      CommunicationId = communicationId,
                      OspTypeId = ospTypeId,
                  };

                if (await this.GetEnitityByAttributes(f032_trmo) == null)
                {
                    await SaveF032_trmoObject(f032_trmo);
                }
            }

            return true;
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
