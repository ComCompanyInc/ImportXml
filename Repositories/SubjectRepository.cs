using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class SubjectRepository : AbstractBaseRepository<Subject>, ISearchData<Subject>
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Subject> GetEnitityByAttributes(Subject entityData)
        {
            IQueryable<Subject> subjectResult = _context.Subjects;

            Subject updatedObject = null;
            if (!entityData.Name.IsNullOrEmpty())
            {
                subjectResult = subjectResult
                    .Where(c => c.Name == entityData.Name);

                Subject existingSubject = await subjectResult.FirstOrDefaultAsync();
                if (existingSubject != null)
                {
                    updatedObject = await UpdateObject(existingSubject, entityData);
                }
            }
            //else {
            //    return await FindDistrictByOkatoAndSubject(entityData.Okato);
            //}

            return updatedObject;
        }

        public async Task<Subject> UpdateObject(Subject existingEntity, Subject entityData)
        {
            if (!entityData.Okato.IsNullOrEmpty())
            {
                existingEntity.Okato = entityData.Okato;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<Subject> FindSubjectByOkato(string Okato)
        {
            return await _context.Subjects.Where(c => c.Okato == Okato)
                .FirstOrDefaultAsync();
        }
    }
}
