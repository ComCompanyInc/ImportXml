using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BackendApp.Services
{
    public class PaymentStatusService
    {
        private readonly PaymentStatusRepository _paymentStatusRepository;

        public PaymentStatusService(PaymentStatusRepository paymentStatusRepository)
        {
            _paymentStatusRepository = paymentStatusRepository;
        }

        public async Task<PaymentStatus> GetEnitityByAttributes(PaymentStatus entityData)
        {
            return await _paymentStatusRepository.GetEnitityByAttributes(entityData);
        }

        public async Task<PaymentStatus> SavePaymentStatusObject(PaymentStatus entityData)
        {
            return await _paymentStatusRepository.SaveData(entityData);
        }
    }
}
