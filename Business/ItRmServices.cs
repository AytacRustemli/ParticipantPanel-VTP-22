using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class ItRmServices
    {
        private readonly ParticipantDbContext _context;

        public ItRmServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<ItRm> GetAll()
        {
            return _context.ItRms.ToList();
        }
        public void Create(ItRm ce)
        {
            _context.Add(ce);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ce = _context.ItRms.Find(id);
            _context.Remove(ce);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.ItRms.Count();
        }
    }
}
