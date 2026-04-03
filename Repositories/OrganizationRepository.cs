using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class OrganizationRepository : AbstractBaseRepository<Organization>
    {
        private readonly ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
