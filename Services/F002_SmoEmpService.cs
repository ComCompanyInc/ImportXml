using BackendApp.Dto;
using BackendApp.Dto.f002_smo_emp;
using BackendApp.Dto.f031_ermos;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F002_SmoEmpService
    {
        private readonly F002_SmoEmpRepository _f002_SmoEmpRepository;

        private readonly BaseDataService _baseDataService;
        private readonly OrgNameService _orgNameService;
        private readonly OrganizationService _organizationService;
        private readonly AddressService _addressService;
        private readonly PersonService _personService;
        private readonly LicenseService _licenseService;
        private readonly F002_InsIncludeService _f002_InsIncludeService;
        private readonly OrgTypeService _orgTypeService;
        private readonly CommunicationService _communicationService;
        private readonly DocumentService _documentService;
        private readonly F002_Smo_InsAdviceService _f002_Smo_InsAdviceService;

        public F002_SmoEmpService(
            F002_SmoEmpRepository f002_SmoEmpRepository,
            BaseDataService baseDataService,
            OrgNameService orgNameService,
            OrganizationService organizationService,
            AddressService addressService,
            PersonService personService,
            LicenseService licenseService,
            F002_InsIncludeService f002_InsIncludeService,
            OrgTypeService orgTypeService,
            CommunicationService communicationService,
            DocumentService documentService,
            F002_Smo_InsAdviceService f002_Smo_InsAdviceService
        )
        {
            _f002_SmoEmpRepository = f002_SmoEmpRepository;

            _baseDataService = baseDataService;
            _organizationService = organizationService;
            _addressService = addressService;
            _personService = personService;
            _licenseService = licenseService;
            _f002_InsIncludeService = f002_InsIncludeService;
            _orgNameService = orgNameService;
            _orgTypeService = orgTypeService;
            _communicationService = communicationService;
            _documentService = documentService;
            _f002_Smo_InsAdviceService = f002_Smo_InsAdviceService;
        }

        public async Task<bool> SaveDataFromF2(F2DataDto dataContainer)
        {
            //return false;

            BaseData baseData = new BaseData
            {
                Version = dataContainer.Version,
                Date = DateTime.ParseExact(dataContainer.Date, "yyyy-MM-dd", null),
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

            foreach (InsCompany item in dataContainer.InsCompanies)
            {
                Address address = new Address
                {
                    Okato = item.Okato,
                    Name = item.jurAddress.AddrJ,
                    Index = item.jurAddress.IndexJ
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

                OrgName orgName = new OrgName
                {
                    Name = item.OrgName,
                    ShortName = item.OrgShortName
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

                OrgType orgType = new OrgType
                {
                    OrgTypeName = item.Org
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

                Organization organization = new Organization
                {
                    OrgNameId = orgNameId,
                    Okopf = item.Okopf,
                    OrgTypeId = orgTypeId
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

                Person person = new Person
                {
                    Surname = item.PersonSurname,
                    Name = item.PersonName,
                    Patronymic = item.PersonPatronymic,
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

                License license = new License
                {
                    LicenseNum = item.license.LicNum, // N_DOC
                    Dstart = DateTime.ParseExact(item.license.DStart, "dd.MM.yyyy", null),
                    DateE = DateTime.ParseExact(item.license.DateE, "dd.MM.yyyy", null),
                    Dterm = string.IsNullOrEmpty(item.license.DTerm)
                        ? null
                        : DateTime.ParseExact(item.license.DTerm, "dd.MM.yyyy", null),
                };

                long licenseId;

                License existingLicense = await _licenseService.GetEnitityByAttributes(license);
                if (existingLicense != null)
                {
                    licenseId = existingLicense.Id;
                }
                else
                {
                    licenseId = (await _licenseService.SaveLicenseObject(license)).Id;
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

                f002_InsInclude f002_InsInclude = new f002_InsInclude
                {
                    NameE = item.insInclude.NameE,
                    DBegin = item.insInclude.DBegin.IsNullOrEmpty()
                             ? null
                             : DateTime.ParseExact(item.insInclude.DBegin, "dd.MM.yyyy", null),
                    DEnd = item.insInclude.DEnd.IsNullOrEmpty()
                            ? null
                            : DateTime.ParseExact(item.insInclude.DEnd, "dd.MM.yyyy", null),
                    NalP = item.insInclude.NalP
                };

                long f002_InsIncludeId;

                f002_InsInclude existingF002_InsInclude = await _f002_InsIncludeService.GetEnitityByAttributes(f002_InsInclude);
                if (existingF002_InsInclude != null)
                {
                    f002_InsIncludeId = existingF002_InsInclude.Id;
                }
                else
                {
                    f002_InsIncludeId = (await _f002_InsIncludeService.SaveInsIncludeObject(f002_InsInclude)).Id;
                }

                f002_smoEmp f002_SmoEmp = new f002_smoEmp
                {
                    SmoCod = item.SmoCode,
                    BaseDataId = baseDataId,
                    AddressId = addressId,
                    OrganizationId = organizationId,
                    DocumentId = documentId,
                    PersonId = personId,
                    CommunicationId = communicationId,
                    LicenseId = licenseId,
                    F002_InsIncludeId = f002_InsIncludeId
                };

                string f002_SmoEmpSmoCode;

                f002_smoEmp existingF002_SmoEmp = await this.GetEnitityByAttributes(f002_SmoEmp);
                if (existingF002_SmoEmp != null)
                {
                    f002_SmoEmpSmoCode = existingF002_SmoEmp.SmoCod;
                }
                else
                {
                    f002_SmoEmpSmoCode = (await this.SaveF002_SpmoEmpObject(f002_SmoEmp)).SmoCod;
                }

                foreach (InsAdvice currentAdvice in item.insAdvices)
                {
                    f002_smo_insAdvice f002_Smo_InsAdvice = new f002_smo_insAdvice
                    {
                        YearWork = currentAdvice.YearWork,
                        Duved = DateTime.ParseExact(currentAdvice.Duved, "dd.MM.yyyy", null),
                        KolZl = currentAdvice.KolZl,
                        F002_SmoEmpSmoCod = f002_SmoEmpSmoCode,
                    };

                    long f002_Smo_InsAdviceId;

                    f002_smo_insAdvice existingF002_Smo_InsAdviceId = await _f002_Smo_InsAdviceService.GetEnitityByAttributes(f002_Smo_InsAdvice);
                    if (existingF002_Smo_InsAdviceId != null)
                    {
                        f002_Smo_InsAdviceId = existingF002_Smo_InsAdviceId.Id;
                    }
                    else
                    {
                        f002_Smo_InsAdviceId = (await _f002_Smo_InsAdviceService.SaveF002_Smo_InsAdviceService(f002_Smo_InsAdvice)).Id;
                    }
                }
            }

            return true;
        }

        public async Task<f002_smoEmp> SaveF002_SpmoEmpObject(f002_smoEmp entityData)
        {
            return await _f002_SmoEmpRepository.SaveData(entityData);
        }

        public async Task<f002_smoEmp> GetEnitityByAttributes(f002_smoEmp entityData)
        {
            return await _f002_SmoEmpRepository.GetEnitityByAttributes(entityData);
        }
    }
}
