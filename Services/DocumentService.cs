using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class DocumentService
    {
        public readonly DocumentRepository _documentRepository;

        public DocumentService(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document> SaveDocumentObject(Document document)
        {
            return await _documentRepository.SaveData(document);
        }
    }
}
