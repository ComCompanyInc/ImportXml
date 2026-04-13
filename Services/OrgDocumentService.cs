using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class OrgDocumentService
    {
        private readonly OrgDocumentRepository _moDocumentRepository;

        public OrgDocumentService (OrgDocumentRepository moDocumentRepository)
        {
            _moDocumentRepository = moDocumentRepository;
        }

        public async Task<OrgDocument> SaveOrgDocument(OrgDocument moDocument)
        {
            return await _moDocumentRepository.SaveData(moDocument);
        }

        public async Task<OrgDocument> GetEnitityByAttributes(OrgDocument moDocument)
        {
            return await _moDocumentRepository.GetEnitityByAttributes(moDocument);
        }
    }
}
