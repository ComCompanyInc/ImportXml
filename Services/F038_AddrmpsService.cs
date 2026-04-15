using BackendApp.Dto;
using BackendApp.Dto.f033_spmo;
using BackendApp.Dto.f038_addrmp;
using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F038_AddrmpsService
    {
        private readonly F038_AddrmpRepository _f038_AddrmpRepository;

        private readonly F032_TrmosService _f032_TrmosService;
        private readonly F033_SpmosService _f033_SpmosService;
        private readonly BaseDataService _baseDataService;
        private readonly AddressService _addressService;

        public F038_AddrmpsService(
            F038_AddrmpRepository f038_AddrmpRepository,
            F032_TrmosService f032_TrmosService,
            F033_SpmosService f033_SpmosService,
            BaseDataService baseDataService,
            AddressService addressService
        )
        {
            _f038_AddrmpRepository = f038_AddrmpRepository;

            _f032_TrmosService = f032_TrmosService;
            _f033_SpmosService = f033_SpmosService;
            _baseDataService = baseDataService;
            _addressService = addressService;
        }

        public async Task<List<ErrorResponseDto>> SaveDataFromF38(DocumentDto<F38DataDto> dataContainer)
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

            foreach (F38DataDto item in dataContainer.ZapList) // перебираем все записи данных листа с данными
            {
                Address address = new Address
                {
                    Name = item.AddressName,
                    AddressCode = item.AddressGar,
                    Index = item.AddressName.Substring(0, 6),
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

                f038_addrmp f038_Addrmp = new f038_addrmp
                {
                    Id = item.Id,
                    BaseDataId = baseDataId,
                    F032_TrmoId = item.F032_TrmosId,
                    F033_SpmoId = item.F033_SpmosId,
                    AddressId = addressId,
                    LicenseNum = item.LicenseNum,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null)
                };

                f032_trmo existingF032 = await _f032_TrmosService.GetEnitityByAttributes(new f032_trmo { Id = item.F032_TrmosId });

                Console.WriteLine("Обьект->>> ");
                Console.WriteLine(existingF032.Id);

                f033_spmo existingF033 = await _f033_SpmosService.GetEnitityByAttributes(new f033_spmo { Id = item.F033_SpmosId });
                if (existingF032 != null)
                {
                    if (existingF033 != null)
                    {
                        SaveF038_addrmpObject(f038_Addrmp);
                    }
                    else
                    {
                        errors.Add(
                            new ErrorResponseDto
                            {
                                ErrorMessage = $"ОШИБКА: В ЗАПИСИ F038_Addrmp с ID = {item.Id} - в таблице F033_Spmo, первичный ключ ID (UIDMO) - {item.F033_SpmosId} не найден. Сначала импортируйте документ F033_Spmo перед загрузкой документа F038_Addrmp!",
                                ConflictObject = f038_Addrmp
                            }
                        );
                    }
                }
                else {
                    errors.Add(
                        new ErrorResponseDto
                        {
                            ErrorMessage = $"ОШИБКА: В ЗАПИСИ F038_Addrmp с ID = {item.Id} - в таблице F032_Trmo, первичный ключ ID (UIDMO) - {item.F032_TrmosId} не найден. Сначала импортируйте документ F032_Trmo перед загрузкой документа F038_Addrmp!",
                            ConflictObject = f038_Addrmp
                        }
                    );
                }
            }

            return errors;
        }

        public async Task<f038_addrmp> SaveF038_addrmpObject(f038_addrmp f038_addrmp)
        {
            return await _f038_AddrmpRepository.SaveData(f038_addrmp);
        }

        public async Task<f038_addrmp> GetEnitityByAttributes(f038_addrmp f038_addrmp)
        {
            return await _f038_AddrmpRepository.GetEnitityByAttributes(f038_addrmp);
        }
    }
}
