using DubTask.Application.Repositories;
using DubTask.Persistence.DbContexts;
using DubTask.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence.Repositories.Repos
{
    public class UserRepository:BaseRepository<Domain.Models.User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
