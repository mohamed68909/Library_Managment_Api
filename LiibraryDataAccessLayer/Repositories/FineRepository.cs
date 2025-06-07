using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Repositories
{
    public class FineRepository : IFineRepository
    {
        private readonly LibraryContext _context;

        public FineRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Fine> GetByUserId(int userId)
        {
            return _context.Fines.Where(f => f.UserId == userId).ToList();
        }

        public Fine GetById(int id)
        {
            return _context.Fines.Find(id);
        }

        public void Update(Fine fine)
        {
            _context.Fines.Update(fine);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
