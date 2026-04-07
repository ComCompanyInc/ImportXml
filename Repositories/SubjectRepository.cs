using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
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

            return await subjectResult.FirstOrDefaultAsync();
        }
    }
}
