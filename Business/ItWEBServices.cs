using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ItWEBServices
    {
        private readonly ParticipantDbContext _context;

        public ItWEBServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<ItWeb> GetAll()
        {
            return _context.ItWebs.ToList();
        }
        public void Create(ItWeb ıtWeb)
        {
            _context.Add(ıtWeb);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var itweb = _context.ItWebs.Find(id);
            _context.Remove(itweb);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.ItWebs.Count();
        }

        public List<AgePercentage> GetAgePercentage()
        {
            List<AgePercentage> universites = _context.ItWebs
                .GroupBy(x => x.Age)
                .Select(x => new AgePercentage(x.Key, x.Count())).ToList();

            return universites;
        }
    }
    public class AgePercentage
    {
        public int Age;
        public int AgeCount;

        public AgePercentage(int Age, int AgeCount)
        {
            this.Age = Age;
            this.AgeCount = AgeCount;
        }
    }
}

