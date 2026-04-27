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

            if (entityData.Name != null)
            {
                subjectResult = subjectResult
                    .Where(c => c.Name == entityData.Name);
            }
            else {
                return await FindDistrictByOkatoAndSubject(entityData.Okato);
            }

            return await subjectResult.FirstOrDefaultAsync();
        }

        public Task<Subject> UpdateObject(Subject existingEntity, Subject entityData)
        {
            throw new NotImplementedException();
        }

        public async Task<Subject> FindDistrictByOkatoAndSubject(string Okato)
        {
            return await _context.Subjects.Where(c => c.Okato == Okato)
                .FirstOrDefaultAsync();
        }
    }
}
