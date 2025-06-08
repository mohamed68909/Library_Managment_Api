using LiibraryDataAccessLayer.Interfaces;
using LiibraryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task <List<User>> GetAllAsync() =>  await _context.Users.ToListAsync();
        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);


        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) _context.Users.Remove(user);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }


}
