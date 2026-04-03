using BackendApp.Dto;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F031_ErmosService
    {
        private readonly F031_ErmosRepository _f031_ErmosRepository;

        private readonly BaseDataService _baseDataService;
        private readonly CommunicationService _comminicationService;
        private readonly OrganizationService _organizationService;
        private readonly DocumentService _documentService;
        private readonly MoDocumentService _moDocumentService;
        private readonly AddressService _addressService;

        public F031_ErmosService(
            F031_ErmosRepository f031_ErmosRepository,
            BaseDataService baseDataService,
            CommunicationService comminicationService,
            OrganizationService organizationService,
            DocumentService documentService,
            MoDocumentService moDocumentService,
            AddressService addressService
        )
        {
            _f031_ErmosRepository = f031_ErmosRepository;

            _baseDataService = baseDataService;
            _comminicationService = comminicationService;
            _organizationService = organizationService;
            _documentService = documentService;
            _moDocumentService = moDocumentService;
            _addressService = addressService;
        }

        /// <summary>
        /// Сохраняет данные из Dto в базу данных
        /// (данные - фрагменты из F031.xml)
        /// </summary>
        /// <returns>Сохраненный обьект</returns>
        public async Task<bool> SaveDataFromF31(f031_ermoDto dataContainer)
        {
            BaseData baseData = new BaseData
            {
                Type = dataContainer.BaseData.Type,
                Version = dataContainer.BaseData.Version,
                Date = DateTime.ParseExact(dataContainer.BaseData.Date, "dd.MM.yyyy", null)
            }; // создаем обьект с заголовком и передаем в него данные из документа

            long baseDataId = (await _baseDataService.SaveBaseDataObject(baseData)).Id;

            foreach (MoDataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                //каждую новую итерацию нового элемента, создаем обьекты с данными из XML и сохраняем его по разным сущностям
                Communication communication = new Communication
                {
                    Phone = item.Phone,
                    Fax = item.Fax,
                    Email = item.Email,
                }; // данные контактов

                long communicationId = (await _comminicationService.SaveCommunicationObject(communication)).Id;

                Organization organization = new Organization
                {
                    Name = item.Name,
                    ShortName = item.ShortName,
                    Okopf = item.Okopf
                };

                long organizationId = (await _organizationService.SaveOrganizationObject(organization)).Id;

                Document document = new Document
                {
                    Inn = item.Inn,
                    Kpp = item.Kpp,
                    Ogrn = item.Ogrn
                };

                long documentId = (await _documentService.SaveDocumentObject(document)).Id;

                MoDocument moDocument = new MoDocument
                {
                    MoId = item.MoId,
                    Okfs = item.Okfs,
                    OidMo = item.OidMo,
                    DateBeg = DateTime.Today
                };

                string moDocumentId = (await _moDocumentService.SaveMoDocument(moDocument)).MoId;

                Address address = new Address
                {
                    Oktmo = item.Oktmo,
                    Name = item.FullAddressName,
                    Index = item.FullAddressName.Substring(0, 6),
                };

                long addressId = (await _addressService.SaveAddressObject(address)).Id;

                f031_ermo f031_ermo = new f031_ermo
                {
                    BaseDataId = baseDataId,
                    MoDocumentId = moDocumentId,
                    OrganizationId = organizationId,
                    DocumentId = documentId,
                    AddressId = addressId,
                    AddressCode = item.AddressCode,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                    CommunicationId = communicationId,
                };

                await SaveF031_ermoObject(f031_ermo);
            }

            return true;
        }

        public async Task<f031_ermo> SaveF031_ermoObject(f031_ermo f031_ermo)
        {
            return await _f031_ErmosRepository.SaveData(f031_ermo);
        }
    }
}
