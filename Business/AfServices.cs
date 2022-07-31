using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class AfServices
    {
        private readonly ParticipantDbContext _context;

        public AfServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<Af> GetAll()
        {
            return _context.Afs.ToList();
        }
        public void Create(Af af)
        {
            _context.Add(af);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var af = _context.Afs.Find(id);
            _context.Remove(af);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.Afs.Count();
        }
    }
}
