using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountServices
    {
        private readonly ParticipantDbContext _context;

        public CountServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<Count> GetAll()
        {
            return _context.Counts.ToList();
        }                                                                                                                                                       
    }
}