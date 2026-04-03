using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class MoDocumentRepository : AbstractBaseRepository<MoDocument>
    {
        private readonly ApplicationDbContext _context;

        public MoDocumentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
