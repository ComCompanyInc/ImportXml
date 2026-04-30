using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class SubjectService
    {
        private readonly SubjectRepository _subjectRepository;

        public SubjectService(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Subject> SaveSubjectObject(Subject subject)
        {
            return await _subjectRepository.SaveData(subject);
        }

        public async Task<Subject> GetEnitityByAttributes(Subject subject)
        {
            return await _subjectRepository.GetEnitityByAttributes(subject);
        }

        public async Task<Subject> FindSubjectByOkato(string okato)
        {
            return await _subjectRepository.FindSubjectByOkato(okato);
        }
    }
}
