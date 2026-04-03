using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class CommunicationService
    {
        private readonly CommunicationRepository _communicationRepository;

        public CommunicationService(CommunicationRepository communicationRepository)
        {
            _communicationRepository = communicationRepository;
        }

        public async Task<Communication> SaveCommunicationObject(Communication communication)
        {
            return await _communicationRepository.SaveData(communication);
        }
    }
}
