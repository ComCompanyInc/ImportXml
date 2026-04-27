using BackendApp.Dto;
using BackendApp.Dto.f005_statopl;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F005_StatOplService
    {
        private readonly F005_StatOplRepository _f005_StatOplRepository;

        private readonly BaseDataService _baseDataService;
        private readonly PaymentStatusService _paymentStatusService;

        public F005_StatOplService(
            F005_StatOplRepository f005_StatOplRepository,
            BaseDataService baseDataService,
            PaymentStatusService paymentStatusService
        )
        {
            _f005_StatOplRepository = f005_StatOplRepository;

            _baseDataService = baseDataService;
            _paymentStatusService = paymentStatusService;
        }

        public async Task<bool> SaveDataFromF5(DocumentDto<F5DataDto> dataContainer)
        {
            BaseData baseData = new BaseData
            {
                Type = dataContainer.BaseData.Type,
                Version = dataContainer.BaseData.Version,
                Date = DateTime.ParseExact(dataContainer.BaseData.Date, "dd.MM.yyyy", null)
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

            foreach (F5DataDto item in dataContainer.ZapList)
            {
                PaymentStatus paymentStatus = new PaymentStatus
                {
                    StatusName = item.Name
                };

                long paymentStatusId;

                PaymentStatus existingPaymentStatus = await _paymentStatusService.GetEnitityByAttributes(paymentStatus);
                if (existingPaymentStatus != null)
                {
                    paymentStatusId = existingPaymentStatus.Id;
                }
                else
                {
                    paymentStatusId = (await _paymentStatusService.SavePaymentStatusObject(paymentStatus)).Id;
                }

                f005_StatOpl f005_StatOpl = new f005_StatOpl
                {
                    BaseDataId = baseDataId,
                    PaymentStatusId = paymentStatusId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                        ? null
                        : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                };

                long f005_StatOplId;

                f005_StatOpl existingf005_StatOpl = await this.GetEnitityByAttributes(f005_StatOpl);
                if (existingf005_StatOpl != null)
                {
                    f005_StatOplId = existingf005_StatOpl.StatusCode;
                }
                else
                {
                    f005_StatOplId = (await this.SaveF005_StatOplObject(f005_StatOpl)).StatusCode;
                }
            }

            return true;
        }

        public async Task<f005_StatOpl> SaveF005_StatOplObject(f005_StatOpl entityData)
        {
            return await _f005_StatOplRepository.SaveData(entityData);
        }

        public async Task<f005_StatOpl> GetEnitityByAttributes(f005_StatOpl entityData)
        {
            return await _f005_StatOplRepository.GetEnitityByAttributes(entityData);
        }
    }
}
