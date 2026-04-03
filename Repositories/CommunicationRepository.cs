using BackendApp.Data;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class CommunicationRepository : AbstractBaseRepository<Communication>
    {
        private readonly ApplicationDbContext _context;

        public CommunicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
