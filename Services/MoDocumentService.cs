using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class MoDocumentService
    {
        private readonly MoDocumentRepository _moDocumentRepository;

        public MoDocumentService (MoDocumentRepository moDocumentRepository)
        {
            _moDocumentRepository = moDocumentRepository;
        }

        public async Task<MoDocument> SaveMoDocument(MoDocument moDocument)
        {
            return await _moDocumentRepository.SaveData(moDocument);
        }
    }
}
