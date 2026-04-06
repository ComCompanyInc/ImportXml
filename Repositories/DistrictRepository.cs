using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class DistrictRepository : AbstractBaseRepository<District>
    {
        private readonly ApplicationDbContext _context;

        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
