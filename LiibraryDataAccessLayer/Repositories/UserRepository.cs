using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiibraryDataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context) => _context = context;

        public List<User> GetAll() => _context.Users.ToList();
        public User? GetById(int id) => _context.Users.Find(id);

     
        public void Update(User user) => _context.Users.Update(user);

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null) _context.Users.Remove(user);
        }

        public void Save() => _context.SaveChanges();
    }


}
