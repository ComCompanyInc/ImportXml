using BackendApp.Dto;
using BackendApp.Dto.f001_tfoms;
using BackendApp.Dto.f010_subecti;
using BackendApp.Dto.f031_ermos;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BackendApp.Services
{
    public class F001_TfomsService
    {
        private readonly F001_TfomsRepository _f001_TfomsRepository;

        private readonly BaseDataService _baseDataService;
        private readonly AddressService _addressService;
        private readonly PersonService _personService;
        private readonly DocumentService _documentService;
        private readonly CommunicationService _communicationService;
        private readonly OrganizationService _organizationService;
        private readonly OrgNameService _orgNameService;
        private readonly SubjectService _subjectService;
        private readonly DistrictService _districtService;
        private readonly AccountService _accountService;
        private readonly F010_SubectiService _f010_SubectiService;

        public F001_TfomsService(
            F001_TfomsRepository f001_TfomsRepository,
            
            BaseDataService baseDataService,
            AddressService addressService,
            PersonService personService,
            DocumentService documentService,
            CommunicationService communicationService,
            OrganizationService organizationService,
            OrgNameService orgNameService,
            SubjectService subjectService,
            DistrictService districtService,
            AccountService accountService,
            F010_SubectiService f010_SubectiService
        )
        {
            _f001_TfomsRepository = f001_TfomsRepository;

            _baseDataService = baseDataService;
            _addressService = addressService;
            _personService = personService;
            _documentService = documentService;
            _communicationService = communicationService;
            _organizationService = organizationService;
            _orgNameService = orgNameService;
            _subjectService = subjectService;
            _districtService = districtService;
            _accountService = accountService;
            _f010_SubectiService = f010_SubectiService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF1(F1Document dataContainer)
        {
            List<ErrorResponseDto> errors = new List<ErrorResponseDto>();

            BaseData baseData = new BaseData
            {
                Type = "TFOMS",
                Version = dataContainer.Version,
                Date = DateTime.ParseExact(dataContainer.Date, "dd.MM.yyyy", null)
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

            foreach (F1DataDto item in dataContainer.F1Data) // перебираем все записи данных листа с данными
            {
                long subjectId;

                Subject existingSubject = await _subjectService.FindSubjectByOkato(item.Okato);
                if (existingSubject != null)
                {
                    subjectId = existingSubject.Id;
                }
                else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Ошибка: Субьект (из таблицы Subject) по идентификатору Okato = "
                                + item.Okato + " не был найден. Требуется заполнить документ F10 и повторить попытку импорта",
                            ConflictObject = existingSubject
                        }
                    );

                    continue;
                }

                District district = new District
                {
                    SubjectId = subjectId
                };

                long districtId;

                District existingDistrictId = await _districtService.GetEnitityByAttributes(district);
                if (existingDistrictId != null)
                {
                    districtId = existingDistrictId.Id;
                }
                else
                {
                    districtId = (await _districtService.SaveDistrictObject(district)).Id;
                }

                Address address = new Address
                {
                    Index = item.index,
                    Name = item.AddressName,
                    Oktmo = item.MtrData.Oktmo,
                    DistrictId = districtId
                };

                long addresId;

                Address existingAddressId = await _addressService.GetEnitityByAttributes(address);
                if (existingAddressId != null)
                {
                    addresId = existingAddressId.Id;
                }
                else
                {
                    addresId = (await _addressService.SaveAddressObject(address)).Id;
                }

                f010_Subecti f010_Subecti = new f010_Subecti
                {
                    CodeTf = item.CodeTf,
                    SubjectId = subjectId,

                    Subject = existingSubject
                };

                long f010_SubjectId;

                f010_Subecti existingF010_Subject = await _f010_SubectiService.GetEnitityByAttributes(f010_Subecti);
                //FindF10BySubjectIdAndDate(
                    //subjectId, null, null
                //);

                //Console.WriteLine("\nexistingF010 -> " + JsonSerializer.Serialize(existingF010_Subject) + "\n");
                //Console.WriteLine("\aAttributes ->\nSubjId = " + subjectId
                //    + "\nDateBeg = " + DateTime.ParseExact(item.DBegin, "dd.MM.yyyy", null)
                //    + "\nDateEnd = " + item.DEnd
                //);

                if (existingF010_Subject != null)
                {
                    f010_SubjectId = existingF010_Subject.Id;
                }
                else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = "Ошибка: Субьект (из таблицы F010_Subecti) по идентификатору SubjectId = "
                                + subjectId + " не был найден. Требуется заполнить документ F10 и повторить попытку импорта",
                            ConflictObject = existingSubject
                        }
                    );

                    continue;
                }

                Document document = new Document
                {
                    Ogrn = item.Ogrn,
                    Inn = item.MtrData.Inn,
                    Kpp = item.MtrData.Kpp
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

                OrgName orgName = new OrgName
                {
                    Name = item.OrgName,
                    ShortName = item.OrgName
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
                    KfTf = item.KfTf,
                    Kbk = item.MtrData.Kbk
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

                Person person = new Person
                {
                    Surname = item.PersonSurame,
                    Name = item.PersonName,
                    Patronymic = item.PersonPatronymic
                };

                long personId;

                Person existingPerson = await _personService.GetEnitityByAttributes(person);
                if (existingPerson != null)
                {
                    personId = existingPerson.Id;
                }
                else
                {
                    personId = (await _personService.SavePersonObject(person)).Id;
                }

                Communication communication = new Communication
                {
                    Phone = item.Phone,
                    Fax = item.Fax,
                    HotLine = item.HotLine,
                    Email = item.Email,
                    Site = item.Site
                };

                long communicationId;

                Communication existingCommunication = await _communicationService.GetEnitityByAttributes(communication);
                if (existingCommunication != null)
                {
                    communicationId = existingCommunication.Id;
                }
                else
                {
                    communicationId = (await _communicationService.SaveCommunicationObject(communication)).Id;
                }

                Account recieverAccount = new Account
                {
                    Name = item.MtrData.MtrPolData.RecieverName,
                    Bank = item.MtrData.MtrPolData.RecieverBank,
                    Rs = item.MtrData.MtrPolData.RecieverRs
                };

                long recieverAccoundId;

                Account existingAccount = await _accountService.GetEnitityByAttributes(recieverAccount);
                if (existingAccount != null)
                {
                    recieverAccoundId = existingAccount.Id;
                }
                else
                {
                    recieverAccoundId = (await _accountService.SaveAccountObject(recieverAccount)).Id;
                }

                Account senderAccount = new Account
                {
                    Name = item.MtrData.MtrPlData.SenderName,
                    Bank = item.MtrData.MtrPlData.SenderBank,
                    Rs = item.MtrData.MtrPlData.SenderRs
                };

                long senderAccoundId;

                existingAccount = await _accountService.GetEnitityByAttributes(senderAccount);
                if (existingAccount != null)
                {
                    senderAccoundId = existingAccount.Id;
                }
                else
                {
                    senderAccoundId = (await _accountService.SaveAccountObject(senderAccount)).Id;
                }

                // сохранение F001
                f001_tfoms f001_Tfoms = new f001_tfoms
                {
                    F010_Subecti = existingF010_Subject,

                    f010_SubectiId = f010_SubjectId,
                    AddressId = addresId,
                    CommunicationId = communicationId,
                    BaseDataId = baseDataId,
                    PersonId = personId,
                    OrganizationId = organizationId,
                    DocumentId = documentId,
                    SenderAccountId = senderAccoundId,
                    ReceiverAccountId = recieverAccoundId,
                    Bic = item.MtrData.Bic,
                    DEdit = item.DEdit.IsNullOrEmpty()
                            ? null
                            : DateTime.ParseExact(item.DEdit, "dd.MM.yyyy", null),
                    DBegin = DateTime.ParseExact(item.DBegin, "dd.MM.yyyy", null),
                    DEnd = item.DEnd.IsNullOrEmpty()
                            ? null
                            : DateTime.ParseExact(item.DEnd, "dd.MM.yyyy", null),
                    NoSmo = item.NoSmo
                };

                long f001_TfomsId;

                f001_tfoms existingF001_Tfoms = await this.GetEnitityByAttributes(f001_Tfoms);
                if (existingF001_Tfoms != null)
                {
                    f001_TfomsId = existingF001_Tfoms.Id;
                }
                else
                {
                    f001_TfomsId = (await this.SaveF001_TfomsObject(f001_Tfoms)).Id;
                }
            }

            return errors;
        }

        public async Task<f001_tfoms> SaveF001_TfomsObject(f001_tfoms entityData)
        {
            return await _f001_TfomsRepository.SaveData(entityData);
        }

        public async Task<f001_tfoms> GetEnitityByAttributes(f001_tfoms entityData)
        {
            return await _f001_TfomsRepository.GetEnitityByAttributes(entityData);
        }
    }
}
