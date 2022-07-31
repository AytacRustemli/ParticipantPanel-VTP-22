using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class HrServices
    {
        private readonly ParticipantDbContext _context;

        public HrServices(ParticipantDbContext context)
        {
            _context = context;
        }

        public List<HR> GetAll()
        {
            return _context.HR.ToList();
        }
        public void Create(HR hr)
        {
            _context.Add(hr);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var hr = _context.HR.Find(id);
            _context.Remove(hr);
            _context.SaveChanges();
        }

        public int GetCount()
        {
            return _context.HR.Count();
        }
    }
}
