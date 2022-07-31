using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class LogisticServices
    {
        private readonly ParticipantDbContext _context;

        public LogisticServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<Logistic> GetAll()
        {
            return _context.Logistics.ToList();
        }
        public void Create(Logistic logistic)
        {
            _context.Add(logistic);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var logistic = _context.Logistics.Find(id);
            _context.Remove(logistic);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.Logistics.Count();
        }
    }
}
