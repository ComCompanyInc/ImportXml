using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class BaseDataRepository : AbstractBaseRepository<BaseData>
    {
        private readonly ApplicationDbContext _context;

        public BaseDataRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
