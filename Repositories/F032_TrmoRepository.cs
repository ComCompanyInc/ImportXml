using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F032_TrmoRepository : AbstractBaseRepository<f032_trmo>
    {
        private readonly ApplicationDbContext _context;

        public F032_TrmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
