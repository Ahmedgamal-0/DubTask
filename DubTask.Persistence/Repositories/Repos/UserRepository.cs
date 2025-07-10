using DubTask.Application.Repositories;
using DubTask.Domain.Models;
using DubTask.Persistence.DbContexts;
using DubTask.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence.Repositories.Repos
{
    public class UserRepository:BaseRepository<Domain.Models.User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context): base(context)
        {
        }

        public Task<User?> GetByEmailAsync(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public Task<User?> GetByIdAsync(Guid id) =>
            _context.Users.FindAsync(id).AsTask();

        public Task AddAsync(User user) =>
            _context.Users.AddAsync(user).AsTask();

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
