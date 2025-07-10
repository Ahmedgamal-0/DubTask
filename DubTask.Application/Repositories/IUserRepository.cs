using DubTask.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<Domain.Models.User>
    {
    }
}
