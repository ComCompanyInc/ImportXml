using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class AddressRepository : AbstractBaseRepository<Address>
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
