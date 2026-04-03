using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F031_ErmosRepository : AbstractBaseRepository<f031_ermo>
    {
        private readonly ApplicationDbContext _context;

        public F031_ErmosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
