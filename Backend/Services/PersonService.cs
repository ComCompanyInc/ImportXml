using BackendApp.Models;
using BackendApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetEnitityByAttributes(Person entityData)
        {
            return await _personRepository.GetEnitityByAttributes(entityData);
        }

        public async Task<Person> SavePersonObject(Person entityData)
        {
            return await _personRepository.SaveData(entityData);
        }
    }
}
