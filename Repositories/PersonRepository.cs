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
    public class PersonRepository : AbstractBaseRepository<Person>, ISearchData<Person>
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person> GetEnitityByAttributes(Person entityData)
        {
            IQueryable<Person> PersonResult = _context.People;

            if (!entityData.Name.IsNullOrEmpty())
            {
                PersonResult = PersonResult
                    .Where(c => c.Name == entityData.Name);
            }

            if (!entityData.Surname.IsNullOrEmpty())
            {
                PersonResult = PersonResult
                    .Where(c => c.Surname == entityData.Surname);
            }

            if (!entityData.Patronymic.IsNullOrEmpty())
            {
                PersonResult = PersonResult
                    .Where(c => c.Patronymic == entityData.Patronymic);
            }

            return await PersonResult.FirstOrDefaultAsync();
        }

        public Task<Person> UpdateObject(Person existingEntity, Person entityData)
        {
            throw new NotImplementedException();
        }
    }
}
